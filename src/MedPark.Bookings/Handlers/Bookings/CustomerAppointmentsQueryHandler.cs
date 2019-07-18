using AutoMapper;
using MedPark.Bookings.Domain;
using MedPark.Bookings.Dto;
using MedPark.Bookings.Queries;
using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Handlers.Bookings
{
    public class CustomerAppointmentsQueryHandler : IQueryHandler<AppointmentQuery, CustomerAppointmentsDto>
    {
        private IMedParkRepository<Appointment> _bookingsRepo;
        private IMedParkRepository<Customer> _patientRepo;
        private IMapper _mapper;

        public CustomerAppointmentsQueryHandler(IMedParkRepository<Appointment> bookingsRepo, IMedParkRepository<Customer> patientRepo, IMapper mapper)
        {
            _bookingsRepo = bookingsRepo;
            _patientRepo = patientRepo;
            _mapper = mapper;
        }

        public async Task<CustomerAppointmentsDto> HandleAsync(AppointmentQuery query)
        {
            Customer patient = await _patientRepo.GetAsync(query.CustomerId);
            IEnumerable<Appointment> bookings = await _bookingsRepo.FindAsync(x => x.PatientId == query.CustomerId);

            if (patient is null)
                throw new MedParkException("bookings_patient_does_not_exist", $"Patient with Id {query.CustomerId} does not exist.");

            CustomerAppointmentsDto result = new CustomerAppointmentsDto()
            {
                PatientDetails = _mapper.Map<CustomerDto>(patient),
                BookingDetails = _mapper.Map<List<AppointmentDto>>(bookings)
            };

            return result;
        }
    }
}

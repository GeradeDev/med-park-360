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
    public class SpecialistAppointmentsQueryHandler : IQueryHandler<AppointmentQuery, SpecialistAppointmentsDto>
    {
        private IMedParkRepository<Appointment> _bookingsRepo;
        private IMedParkRepository<Specialist> _specialistRepo;
        private IMapper _mapper;

        public SpecialistAppointmentsQueryHandler(IMedParkRepository<Appointment> bookingsRepo, IMedParkRepository<Specialist> specialistRepo, IMapper mapper)
        {
            _bookingsRepo = bookingsRepo;
            _specialistRepo = specialistRepo;
            _mapper = mapper;
        }

        public async Task<SpecialistAppointmentsDto> HandleAsync(AppointmentQuery query)
        {
            Specialist doctor = await _specialistRepo.GetAsync(query.SpecialistId);
            IEnumerable<Appointment> bookings = await _bookingsRepo.FindAsync(x => x.PatientId == query.SpecialistId);

            if (doctor is null)
                throw new MedParkException("bookings_specialist_does_not_exist", $"Specialist with Id {query.SpecialistId} does not exist.");

            SpecialistAppointmentsDto result = new SpecialistAppointmentsDto()
            {
                SpecialisttDetails = _mapper.Map<SpecialistDto>(doctor),
                BookingDetails = _mapper.Map<List<AppointmentDto>>(bookings)
            };

            return result;
        }
    }
}

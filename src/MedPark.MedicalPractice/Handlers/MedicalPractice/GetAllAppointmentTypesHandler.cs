using AutoMapper;
using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.MedicalPractice.Domain;
using MedPark.MedicalPractice.Dto;
using MedPark.MedicalPractice.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Handlers.MedicalPractice
{
    public class GetAllAppointmentTypesHandler : IQueryHandler<AppointmentTypeQuery, List<AppointmentTypeDTO>>
    {
        private IMedParkRepository<AppointmentType> _appointmentTypeRepo;
        private IMapper _mapper;

        public GetAllAppointmentTypesHandler(IMedParkRepository<AppointmentType> appointmentTypeRepo, IMapper mapper)
        {
            _appointmentTypeRepo = appointmentTypeRepo;
            _mapper = mapper;
        }

        public async Task<List<AppointmentTypeDTO>> HandleAsync(AppointmentTypeQuery query)
        {
            IEnumerable<AppointmentType> appTypes = await _appointmentTypeRepo.GetAllAsync();

            return _mapper.Map<List<AppointmentTypeDTO>>(appTypes);
        }
    }
}

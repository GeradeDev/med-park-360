using AutoMapper;
using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.Types;
using MedPark.MedicalPractice.Domain;
using MedPark.MedicalPractice.Dto;
using MedPark.MedicalPractice.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Handlers.MedicalPractice
{
    public class GetSpecialistAppointmentTypesHandler : IQueryHandler<AppointmentTypeQuery, SpecialistAppointmentTypesDTO>
    {
        private IMedParkRepository<AppointmentType> _appointmentTypeRepo;
        private IMedParkRepository<AppointmentAccepted> _acceptedAppointmentTypeRepo;
        private IMedParkRepository<Specialist> _specialistRepo;
        private IMapper _mapper;

        public GetSpecialistAppointmentTypesHandler(IMedParkRepository<AppointmentType> appointmentTypeRepo, IMedParkRepository<AppointmentAccepted> acceptedAppointmentTypeRepo, IMapper mapper, IMedParkRepository<Specialist> specialistRepo)
        {
            _appointmentTypeRepo = appointmentTypeRepo;
            _acceptedAppointmentTypeRepo = acceptedAppointmentTypeRepo;
            _specialistRepo = specialistRepo;
            _mapper = mapper;
        }

        public async Task<SpecialistAppointmentTypesDTO> HandleAsync(AppointmentTypeQuery query)
        {
            var linkedAppointmentTypes = await _acceptedAppointmentTypeRepo.FindAsync(x => x.SpecialistId == query.SpecialistId);

            var specialist = await _specialistRepo.GetAsync(query.SpecialistId);

            if (specialist is null)
                throw new MedParkException("specialist_does_not_Exist", $"The specialist {query.SpecialistId} does not exists.");

            SpecialistAppointmentTypesDTO dto = new SpecialistAppointmentTypesDTO
            {
                SpecialistId = query.SpecialistId,
                SpecialistName = specialist.FirstName + " " + specialist.Surname,
            };

            var ids = linkedAppointmentTypes.ToList().Select(x => x.Id).ToList();
            IEnumerable<AppointmentType> appTypes = await _appointmentTypeRepo.FindAsync(x => ids.Contains(x.Id));

            dto.TypesLinkedToSpecilaist.AddRange(_mapper.Map<List<AppointmentTypeDTO>>(appTypes));

            return dto;
        }
    }
}

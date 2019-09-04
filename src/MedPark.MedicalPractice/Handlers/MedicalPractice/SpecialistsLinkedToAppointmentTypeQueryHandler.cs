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
    public class SpecialistsLinkedToAppointmentTypeQueryHandler : IQueryHandler<SpecialistsLinkedToAppointmentTypeQuery, AppointmentTypeSpecialistDTO>
    {
        private IMedParkRepository<AppointmentType> _appointmentTypeRepo;
        private IMedParkRepository<AppointmentAccepted> _acceptedAppointmentTypeRepo;
        private IMedParkRepository<Specialist> _specialistRepo;
        private IMapper _mapper;

        public SpecialistsLinkedToAppointmentTypeQueryHandler(IMedParkRepository<AppointmentType> appointmentTypeRepo, IMedParkRepository<AppointmentAccepted> acceptedAppointmentTypeRepo, IMapper mapper, IMedParkRepository<Specialist> specialistRepo)
        {
            _appointmentTypeRepo = appointmentTypeRepo;
            _acceptedAppointmentTypeRepo = acceptedAppointmentTypeRepo;
            _specialistRepo = specialistRepo;
            _mapper = mapper;
        }

        public async Task<AppointmentTypeSpecialistDTO> HandleAsync(SpecialistsLinkedToAppointmentTypeQuery query)
        {
            AppointmentTypeSpecialistDTO result = new AppointmentTypeSpecialistDTO();

            var appointmentType = await _appointmentTypeRepo.GetAsync(query.AppointmentTypeId);

            if (appointmentType is null)
                throw new MedParkException("appointment_type_does_not_Exist", $"The appointment type {query.AppointmentTypeId} does not exists.");

            result.AppointmentTypeId = query.AppointmentTypeId;
            result.AppointmentTypeName = appointmentType.Name;

            var linked = await _acceptedAppointmentTypeRepo.FindAsync(x => x.AppointmentTypeId == query.AppointmentTypeId);

            var specialistsLinked = await _specialistRepo.FindAsync(x => linked.ToList().Select(s => s.SpecialistId).Contains(x.Id));

            var specialistsMapped = _mapper.Map<SpecialistDetailDTO[]>(specialistsLinked.ToList());

            result.Specilists.AddRange(specialistsMapped);

            return result;
        }
    }
}

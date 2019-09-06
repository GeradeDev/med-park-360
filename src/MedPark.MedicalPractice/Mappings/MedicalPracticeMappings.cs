using AutoMapper;
using MedPark.MedicalPractice.Domain;
using MedPark.MedicalPractice.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Mappings
{
    public class MedicalPracticeMappings : Profile
    {
        public MedicalPracticeMappings()
        {
            CreateMap<Specialist, SpecialistDto>();
            CreateMap<Specialist, SpecialistDetailDTO>();
            CreateMap<PendingRegistration, PendingRegistrationDto>();
            CreateMap<Practice, PracticeDto>();
            CreateMap<Address, PracticeAddressDTO>();
            CreateMap<OperatingHours, OperatingHoursDTO>();
            CreateMap<AppointmentType, AppointmentTypeDTO>();
            CreateMap<Institute, InstituteDTO>();
            CreateMap<MedicalScheme, MedicalSchemeDTO>();
            CreateMap<MedicalScheme, MedicalSchemeDTO>();
            CreateMap<Qualifications, SpecialistQualificationDTO>();
            CreateMap<AcceptedMedicalScheme, AcceptedMedicalSchemeDTO>();
        }
    }
}

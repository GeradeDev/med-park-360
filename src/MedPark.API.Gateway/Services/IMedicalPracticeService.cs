using MedPark.API.Gateway.Models;
using MedPark.API.Gateway.Models.MedicalPractice;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.API.Gateway.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IMedicalPracticeService
    {
        //PRACTICE
        [Get("/practice/{id}")]
        Task<SpecialistDto> GetPracticeById([Path] Guid id);

        [Get("/practice/getPracticeDetails/{id}")]
        Task<PracticeDetailDTO> GetPracticeDetailById([Path] Guid id);


        //SPECIALIST
        [Get("/specialist/{id}")]
        Task<SpecialistDto> GetSpecialist([Path] Guid id);

        [Get("/registration/{otp}")]
        Task<PendingRegistrationDto> GetRegistrationOTP([Path] Int32 otp);


        //ACCEPTABLE MEDICAL SCHEMES
        [Get("/acceptableschemes/{practiceid}")]
        Task<AcceptedMedicalSchemeDTO> GetAcceptedSchemesByPracticeId([Path] Guid practiceid);


        //Institute
        [Get("/institute/{id}")]
        Task<InstituteDTO> GetInstituteById([Path] Guid id);


        //Medical Scheme
        [Get("/medicalschemes/{schemeid}")]
        Task<MedicalSchemeDTO> GetMedicalSchemeById([Path] Guid schemeid);


        //Operating Hours
        [Get("/operatinghours/{practiceid}")]
        Task<OperatingHoursDTO> GetOperatingHoursByPracticeId([Path] Guid practiceid);


        //Specialist Qualifications
        [Get("/qualifications/{specialistid}")]
        Task<SpecialistQualificationDTO> GetSpecialistQualifications([Path] Guid specialistid);
    }
}

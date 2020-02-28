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
        Task<PracticeDto> GetPracticeById([Path] Guid id);

        [Get("/practice/getPracticeDetails/{id}")]
        Task<PracticeDetailDTO> GetPracticeDetailById([Path] Guid id);


        //SPECIALIST
        [Get("/specialist/{id}")]
        Task<SpecialistDto> GetSpecialist([Path] Guid id);

        [Get("/registration/{otp}")]
        Task<PendingRegistrationDto> GetRegistrationOTP([Path] Int32 otp);


        //ACCEPTABLE MEDICAL SCHEMES
        [Get("/acceptableschemes/{practiceid}")]
        Task<List<AcceptedMedicalSchemeDTO>> GetAcceptedSchemesByPracticeId([Path] Guid practiceid);


        //Institute
        [Get("/institute/{id}")]
        Task<InstituteDTO> GetInstituteById([Path] Guid id);


        //Medical Scheme
        [Get("/medicalschemes/{schemeid}")]
        Task<MedicalSchemeDTO> GetMedicalSchemeById([Path] Guid schemeid);


        //Operating Hours
        [Get("/operatinghours/specialistpracticehours/{practiceid}/{specialistid}")]
        Task<OperatingHoursDTO> GetSpecialistPracticeHoursDetails([Path] Guid practiceid, [Path] Guid specialistid);


        //Specialist Qualifications
        [Get("/qualifications/{specialistid}")]
        Task<SpecialistQualificationDTO> GetSpecialistQualifications([Path] Guid specialistid);


        //appointment Types
        [Get("/appointmenttype/")]
        Task<List<AppointmentTypeDTO>> GetAllAppointmentTypes();
        
        [Get("/appointmenttype/getBySpecialist/{specialistid}")]
        Task<SpecialistAppointmentTypesDTO> GetAppointmentTypesBySpecialistId([Path] Guid specialistid);

        [Get("/appointmenttype/getSpecialistByAppointment/{appointmenttypeid}")]
        Task<AppointmentTypeSpecialistDTO> GetSpecialistByAppointmentType([Path] Guid appointmenttypeid);
    }
}

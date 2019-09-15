using MedPark.Bookings.Model.MedicalPracticeService;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface ISpecialistService
    {
        [Get("/practice/practiceaddress/{practiceid}")]
        Task<PracticeAddressDTO> GetSpecialistAddress([Path] Guid practiceid);

        [Get("/acceptableschemes/getscheme/{schemeid}")]
        Task<AcceptedMedicalSchemeDTO> GetSchemeById([Path] Guid schemeid);

        [Get("/practice/{id}")]
        Task<PracticeDto> GetPracticeDetails([Path] Guid id);

        [Get("/appointmenttype/getbyid/{appointmenttypeid}")]
        Task<SpecialistAppointmentTypesDTO> GetAppointmentTypeDetails([Path] Guid appointmenttypeid);

    }
}

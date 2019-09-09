using MedPark.API.Gateway.Models.BookingService;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.API.Gateway.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IBookingService
    {
        [Get("/appointments/getspecialistappointments/{specialistid}")]
        Task<SpecialistAppointmentsDto> GetSpecialistAppointments([Path] Guid specialistid);

        [Get("/appointments/getpatientappointments/{customerid}")]
        Task<CustomerAppointmentsDto> GetPatientAppointments([Path] Guid customerid);

        [Get("/appointments/{appointmentid}/details")]
        Task<AppointmentDetailDto> GetAppointmentDetail([Path] Guid appointmentid);
    }
}

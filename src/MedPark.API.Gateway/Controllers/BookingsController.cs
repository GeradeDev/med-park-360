using MedPark.API.Gateway.Messages.Commands.BookingService;
using MedPark.API.Gateway.Services;
using MedPark.Common;
using MedPark.Common.RabbitMq;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MedPark.API.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase 
    {
        private IBusPublisher _busPublisher { get; set; }
        private IBookingService _bookingService;

        public BookingsController(IBusPublisher busPublisher, IBookingService bookingService)
        {
            _busPublisher = busPublisher;
            _bookingService = bookingService;
        }

        [HttpGet("getspecialistappointments/{specialistid}")]
        public async Task<IActionResult> GetAppointmentsBySpecialistId([FromRoute] Guid specialistid)
        {
            var specialistAppointments = await _bookingService.GetSpecialistAppointments(specialistid);

            return Ok(specialistAppointments);
        }

        [HttpGet("getpatientappointments/{customerid}")]
        public async Task<IActionResult> GetAppointmentsByPatientId([FromRoute] Guid customerid)
        {
            var patientAppointments = await _bookingService.GetPatientAppointments(customerid);

            return Ok(patientAppointments);
        }

        [HttpGet("{appointmentid}/details")]
        public async Task<IActionResult> GetAppointmentDetails([FromRoute] Guid appointmentid)
        {
            var appointmentDetail = await _bookingService.GetAppointmentDetail(appointmentid);

            return Ok(appointmentDetail);
        }

        [HttpPost("addappointment")]
        public async Task<IActionResult> AddNewAppointment([FromBody] AddAppointment command)
        {
            await _busPublisher.SendAsync(command.Bind(x => x.AppointmentId, Guid.NewGuid()), null);

            return Accepted();
        }
    }
}
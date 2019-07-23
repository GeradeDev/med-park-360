using MedPark.API.Gateway.Messages.Commands.BookingService;
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

        public BookingsController(IBusPublisher busPublisher)
        {
            _busPublisher = busPublisher;
        }

        [HttpPost("addappointment")]
        public async Task<IActionResult> AddNewAppointment([FromBody] AddAppointment command)
        {
            await _busPublisher.SendAsync(command.Bind(x => x.AppointmentId, Guid.NewGuid()), null);

            return Accepted();
        }
    }
}
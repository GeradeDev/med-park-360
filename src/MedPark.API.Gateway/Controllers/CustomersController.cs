using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedPark.API.Gateway.Messages.Commands;
using MedPark.API.Gateway.Messages.Events;
using MedPark.Common.RabbitMq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedPark.API.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IBusPublisher _busPublisher;

        public CustomersController(IBusPublisher busPublisher)
        {
            _busPublisher = busPublisher;
        }

        [HttpPost("CreateAddress")]
        public async Task<IActionResult> CreateAddress()
        {
            try
            {
                CreateAddress command = new CreateAddress(Guid.NewGuid(), "4 21st street", "Menlo Park", "Pretoria", "0081", 1, Guid.Parse("BA9DC2C6-D40A-4115-AF7B-DB78CC9EFB8F"));

                //Publish message to RabbitMq
                await _busPublisher.PublishAsync(new AddressCreated(command.AddressLine1, command.AddressLine2, command.AddressLine3, command.PostalCode, command.AddressType, command.UserId), CorrelationContext.Empty);

            }
            catch (Exception ex) { }
            
            return Accepted();
        }
    }
}
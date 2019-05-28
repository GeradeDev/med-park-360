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
        public async Task<IActionResult> CreateAddress(CreateAddress command)
        {
            try
            {
                //Publish message to RabbitMq
                await _busPublisher.PublishAsync(new AddressCreated(command.Id, command.AddressLine1, command.AddressLine2, command.AddressLine3, command.PostalCode, command.AddressType, command.UserId), CorrelationContext.Empty);

            }
            catch (Exception ex) { }
            
            return Accepted();
        }

        [HttpGet("GetAddreses/{userid}")]
        public async Task<IActionResult> GetAddreses(Guid userid)
        {
            try
            {
               
            }
            catch (Exception ex) { }

            return Accepted();
        }
    }
}
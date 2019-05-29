using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedPark.API.Gateway.Messages.Commands;
using MedPark.API.Gateway.Messages.Events;
using MedPark.API.Gateway.Services;
using MedPark.Common.Dispatchers;
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
        private readonly ICustomerService _customerService;

        public CustomersController(IBusPublisher busPublisher, ICustomerService customerService)
        {
            _busPublisher = busPublisher;
            _customerService = customerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var customer = await _customerService.GetCustomer(id);

            return Ok(customer);
        }

        [HttpPost("CreateAddress")]
        public async Task<IActionResult> CreateAddress([FromQuery] CreateAddress command)
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
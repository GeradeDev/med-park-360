using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedPark.API.Gateway.Messages.Commands;
using MedPark.API.Gateway.Messages.Commands.CustomerService;
using MedPark.API.Gateway.Services;
using MedPark.Common;
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
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddress command)
        {
            try
            {
                await _busPublisher.SendAsync(command.BindId(x => x.Id), CorrelationContext.Empty);
            }
            catch (Exception ex) { }
            
            return Accepted();
        }

        [HttpGet("GetAddreses/{userid}")]
        public async Task<IActionResult> GetAddreses(Guid userid)
        {
            try
            {
                var addresses = await _customerService.GetAddreses(userid);

                return Ok(addresses);
            }
            catch (Exception ex) { }

            return BadRequest();
        }

        [HttpPost("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomerDetails([FromBody] UpdateCustomerDetails command)
        {
            try
            {
                await _busPublisher.SendAsync(command, CorrelationContext.Empty);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Accepted();
        }
    }
}
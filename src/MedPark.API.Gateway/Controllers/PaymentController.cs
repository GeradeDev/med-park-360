using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedPark.API.Gateway.Services;
using MedPark.Common;
using MedPark.Common.RabbitMq;
using MedPark.Payment.Messages.Commands.PaymentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedPark.API.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IBusPublisher _busPublisher;
        private IPaymentService _paymentService;

        public PaymentController(IBusPublisher busPublisher, IPaymentService paymentService)
        {
            _busPublisher = busPublisher;
            _paymentService = paymentService;
        }

        [HttpPost("{customerid}")]
        public async Task<IActionResult> Get(Guid customerid)
        {
            var methods = await _paymentService.GetPaymentMethodsByCustomerId(customerid);

            return Ok(methods);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddPaymentMethod command)
        {
            await _busPublisher.SendAsync<AddPaymentMethod>(command.BindId(x => x.Id), null);

            return Accepted();
        }
    }
}
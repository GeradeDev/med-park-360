using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public PaymentController(IBusPublisher busPublisher)
        {
            _busPublisher = busPublisher;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Add([FromBody] AddPaymentMethod command)
        {
            await _busPublisher.SendAsync<AddPaymentMethod>(command.BindId(x => x.Id), null);

            return Accepted();
        }
    }
}
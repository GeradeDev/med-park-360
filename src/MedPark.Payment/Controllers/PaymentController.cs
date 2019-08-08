using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedPark.Common.Dispatchers;
using MedPark.Payment.Dto;
using MedPark.Payment.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedPark.Payment.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IDispatcher _dispatcher { get; }

        public PaymentController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("{customerid}")]
        public async Task<IActionResult> GetCustomerPaymentMethods([FromRoute] GetBuyerPaymentMethods query)
        {
            try
            {
                IEnumerable<PaymentMethodDto> customerMethods = await _dispatcher.QueryAsync(query);

                return Ok(customerMethods);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
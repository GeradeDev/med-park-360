using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedPark.Common.Dispatchers;
using MedPark.OrderService.Dto;
using MedPark.OrderService.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedPark.OrderService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IDispatcher _dispatcher { get; }

        public OrderController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("{orderid}")]
        public async Task<IActionResult> Get([FromRoute] OrderQuery query)
        {
            OrderDetailDto orderSummary = await _dispatcher.QueryAsync<OrderDetailDto>(query);

            return Ok(orderSummary);
        }

        [HttpGet("{orderid}/summary")]
        public async Task<IActionResult> GetSummary([FromRoute] OrderQuery query)
        {
            OrderSummaryDto orderSummary = await _dispatcher.QueryAsync<OrderSummaryDto>(query);

            return Ok(orderSummary);
        }
    }
}
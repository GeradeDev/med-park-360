using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedPark.Basket.Dto;
using MedPark.Basket.Messaging.Commands;
using MedPark.Basket.Queries;
using MedPark.Common;
using MedPark.Common.Cache;
using MedPark.Common.Dispatchers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedPark.Basket.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private IDispatcher _dispatcher { get; }

        public BasketController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("{customerid}")]
        //[Cached(Constants.Day_In_Seconds)]
        public async Task<IActionResult> Get([FromRoute] BasketQuery query)
        {
            var basket = await _dispatcher.QueryAsync<BasketDto>(query);

            return Ok(basket);
        }
    }
}
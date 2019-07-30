using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedPark.API.Gateway.Messages.Commands.BasketService;
using MedPark.API.Gateway.Services;
using MedPark.Common;
using MedPark.Common.RabbitMq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedPark.API.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBusPublisher _busPublisher;
        private readonly IBasketService _basketService;

        public BasketController(IBusPublisher busPublisher, IBasketService basketService)
        {
            _busPublisher = busPublisher;
            _basketService = basketService;
        }

        [HttpGet("{customerid}")]
        public async Task<IActionResult> GetCustomerBasket(Guid customerid)
        {
            var basket = await _basketService.GetBasketByCustomerId(customerid);

            return Ok(basket);
        }


        [HttpPost("createbasket")]
        public async Task<IActionResult> CreateBasket([FromBody] CreateBasket command)
        {
            await _busPublisher.SendAsync(command.Bind(x => x.BasketId, Guid.NewGuid()), null);

            return Accepted();
        }

        [HttpPost("addproduct")]
        public async Task<IActionResult> UpdateBasket([FromBody] AddProductToBasket command)
        {
            await _busPublisher.SendAsync(command.Bind(x => x.Item.Id, Guid.NewGuid()), null);

            return Accepted();
        }

        [HttpPost("updatebasket")]
        public async Task<IActionResult> UpdateBasket([FromBody] UpdateBasket command)
        {
            await _busPublisher.SendAsync(command, null);

            return Accepted();
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> CheckoutBasket([FromBody] CheckoutBasket command)
        {
            await _busPublisher.SendAsync(command, null);

            return Accepted();
        }
    }
}
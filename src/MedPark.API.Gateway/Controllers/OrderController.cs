﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedPark.API.Gateway.Services;
using MedPark.Common.RabbitMq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedPark.API.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBusPublisher _busPublisher;
        private readonly IOrderService _orderService;

        public OrderController(IBusPublisher busPublisher, IOrderService orderService)
        {
            _busPublisher = busPublisher;
            _orderService = orderService;
        }

        [HttpGet("{orderid}")]
        public async Task<IActionResult> Get(Guid orderid)
        {
            var orderDetail = await _orderService.GetOrderById(orderid);

            return Ok(orderDetail);
        }

        [HttpGet("{orderid}/summary")]
        public async Task<IActionResult> GetOrderSummary(Guid orderid)
        {
            var orderSummary = await _orderService.GetOrderSummary(orderid);

            return Ok(orderSummary);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MedPark.Common.Dispatchers;
using MedPark.CustomersService.Dto;
using MedPark.CustomersService.Messages.Commands;
using MedPark.CustomersService.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedPark.CustomersService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public AddressController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<AddressDto>>> Get([FromRoute] GetCustomerAddress query)
        {
            try
            {
                var addresses = await _dispatcher.QueryAsync(query);

                return Ok(addresses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MedPark.Common.Dispatchers;
using MedPark.CustomersService.Dto;
using MedPark.CustomersService.Messages.Commands;
using MedPark.CustomersService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedPark.CustomersService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;
        private readonly IDispatcher _dispatcher;

        public AddressController(ICustomerRepository customerRepo, IMapper mapper, IDispatcher dispatcher)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
            _dispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateAddress command)
        {
            await _dispatcher.SendAsync(command);

            return Accepted();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDto>> Get(Guid id)
        {
            var customer = await _customerRepo.GetAsync(id);

            return Ok(_mapper.Map<AddressDto>(customer));
        }
    }
}
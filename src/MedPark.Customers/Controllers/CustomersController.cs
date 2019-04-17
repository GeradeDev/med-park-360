using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MedPark.Common.Dispatchers;
using MedPark.Common.Handlers;
using MedPark.CustomersService.Dto;
using MedPark.CustomersService.Messages.Commands;
using MedPark.CustomersService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MedPark.CustomersService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;
        private readonly IDispatcher _dispatcher;

        public CustomersController(ICustomerRepository customerRepo, IMapper mapper, IDispatcher dispatcher)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
            _dispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateCustomer command)
        {
            await _dispatcher.SendAsync(command);

            return Accepted();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()
        {
            var customers = await _customerRepo.GetAsync(Guid.NewGuid());

            return Ok(_mapper.Map<CustomerDto[]>(customers));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> Get(Guid id)
        {
            var customer = await _customerRepo.GetAsync(id);

            return Ok(_mapper.Map<CustomerDto>(customer));
        }
        
    }
}

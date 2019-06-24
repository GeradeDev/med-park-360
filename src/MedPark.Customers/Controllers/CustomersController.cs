using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MedPark.Common.Dispatchers;
using MedPark.Common.Handlers;
using MedPark.CustomersService.Dto;
using MedPark.CustomersService.Messages.Commands;
using MedPark.CustomersService.Queries;
using MedPark.CustomersService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MedPark.CustomersService.Controllers
{
    [Route("[controller]")]
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

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> Get([FromRoute] GetCustomer query)
        {
            var customer = await _dispatcher.QueryAsync(query);

            return Ok(customer);
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
            var customers = await _customerRepo.GetAsync(x => x.Birthday < DateTime.Now);

            return Ok(_mapper.Map<CustomerDto[]>(customers));
        }
        
    }
}

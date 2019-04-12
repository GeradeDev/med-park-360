using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MedPark.CustomersService.Dto;
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

        public CustomersController(ICustomerRepository customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
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

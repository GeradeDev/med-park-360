using MedPark.CustomersService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedPark.Common.Handlers;
using MedPark.CustomersService.Queries;
using MedPark.CustomersService.Repositories;

namespace MedPark.CustomersService.Handlers.Customers
{
    public class GetCustomerHandler : IQueryHandler<GetCustomer, CustomerDto>
    {
        private readonly ICustomerRepository _custRepo;

        public GetCustomerHandler(ICustomerRepository custRepo)
        {
            _custRepo = custRepo;
        }

        public async Task<CustomerDto> HandleAsync(GetCustomer query)
        {
            var customer = await _custRepo.GetAsync(query.Id);

            return new CustomerDto()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Avatar = customer.Avatar,
                Birthday = customer.Birthday,
                Mobile = customer.Mobile
            };
        }
    }
}

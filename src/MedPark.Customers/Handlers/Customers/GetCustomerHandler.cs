using MedPark.CustomersService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedPark.Common.Handlers;
using MedPark.CustomersService.Queries;
using MedPark.Common;
using MedPark.CustomersService.Domain;

namespace MedPark.CustomersService.Handlers.Customers
{
    public class GetCustomerHandler : IQueryHandler<GetCustomer, CustomerDto>
    {
        private IMedParkRepository<Customer> _customerRepo { get; }

        public GetCustomerHandler(IMedParkRepository<Customer> customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<CustomerDto> HandleAsync(GetCustomer query)
        {
            var customer = await _customerRepo.GetAsync(query.Id);

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

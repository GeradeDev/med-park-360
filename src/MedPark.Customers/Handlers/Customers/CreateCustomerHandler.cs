using MedPark.Common.Handlers;
using MedPark.Common.Types;
using MedPark.CustomersService.Domain;
using MedPark.CustomersService.Messages.Commands;
using MedPark.CustomersService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.CustomersService.Handlers.Customers
{
    public class CreateCustomerHandler : ICommandHandler<CreateCustomer>
    {
        private readonly ICustomerRepository _customerRepo;

        public CreateCustomerHandler(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task HandleAsync(CreateCustomer command)
        {
            var customer = await _customerRepo.GetAsync(x => x.Email == command.Email);

            if(customer != null)
            {
                //Error: Already exists
                throw new MedParkException("customer_already_exists", $"Customer account was already created for user with id: '{command.Id}'.");
            }

            customer = new Customer(command.Id, command.Email);

            customer.Create(command.FirstName, command.LastName, command.Mobile);

            await _customerRepo.AddAsync(customer);
        }
    }
}

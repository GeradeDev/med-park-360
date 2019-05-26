using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.CustomersService.Domain;
using MedPark.CustomersService.Messages.Events;
using MedPark.CustomersService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.CustomersService.Handlers.Identity
{
    public class SignedUpHandler : IEventHandler<SignedUp>
    {
        private readonly ICustomerRepository _customerRepo;

        public SignedUpHandler(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task HandleAsync(SignedUp @event, ICorrelationContext context)
        {
            var customer = new Customer(@event.UserId, @event.Email);

            customer.Create(@event.FirstName);

            await _customerRepo.AddAsync(customer);
        }
    }
}

using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.CustomersService.Domain;
using MedPark.CustomersService.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.CustomersService.Handlers.Identity
{
    public class SignedUpHandler : IEventHandler<SignedUp>
    {
        private IMedParkRepository<Customer> _customerRepo { get; }

        public SignedUpHandler(IMedParkRepository<Customer> customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task HandleAsync(SignedUp @event, ICorrelationContext context)
        {
            var customer = new Customer(@event.UserId, @event.Email);

            customer.Create(@event.FirstName, @event.AccountType);

            await _customerRepo.AddAsync(customer);
        }
    }
}

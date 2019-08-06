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
        private IBusPublisher _busPublisher;

        public SignedUpHandler(IMedParkRepository<Customer> customerRepo, IBusPublisher busPublisher)
        {
            _customerRepo = customerRepo;
            _busPublisher = busPublisher;
        }

        public async Task HandleAsync(SignedUp @event, ICorrelationContext context)
        {
            Customer customer = new Customer(@event.UserId);
            customer.Create(@event.FirstName, @event.AccountType, @event.LastName);
            customer.SetEmail(@event.Email);

            customer.Use();

            await _customerRepo.AddAsync(customer);

            //Publish event that new customer has signed up
            CustomerCreated customerCreated = new CustomerCreated(@event.UserId, @event.FirstName, @event.LastName, @event.Email, "");
            await _busPublisher.PublishAsync(customerCreated, null);
        }
    }
}

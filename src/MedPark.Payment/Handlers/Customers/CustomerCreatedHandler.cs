using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.Payment.Domain;
using MedPark.Payment.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Payment.Handlers.Customers
{
    public class CustomerCreatedHandler : IEventHandler<CustomerCreated>
    {
        private IMedParkRepository<Customer> _customerRepo { get; }

        public CustomerCreatedHandler(IMedParkRepository<Customer> customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task HandleAsync(CustomerCreated @event, ICorrelationContext context)
        {
            Customer customer = new Customer(@event.UserId);

            customer.SetCustomer(@event.UserId, @event.FirstName, @event.LastName);

            customer.Use();

            await _customerRepo.AddAsync(customer);
        }
    }
}

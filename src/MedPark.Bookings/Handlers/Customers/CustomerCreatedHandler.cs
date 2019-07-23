using MedPark.Bookings.Domain;
using MedPark.Bookings.Messages.Events;
using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Handlers
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

            customer.Create(@event.FirstName, @event.Mobile, @event.LastName, @event.Email);

            await _customerRepo.AddAsync(customer);
        }
    }
}

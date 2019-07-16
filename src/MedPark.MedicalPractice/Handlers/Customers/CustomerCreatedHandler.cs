using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.CustomersService.Messages.Events;
using MedPark.MedicalPractice.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Handlers.Customers
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

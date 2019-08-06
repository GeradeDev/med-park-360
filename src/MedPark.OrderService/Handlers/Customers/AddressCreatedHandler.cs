using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.Common.Types;
using MedPark.OrderService.Domain;
using MedPark.OrderService.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.OrderService.Handlers.Customers
{
    public class AddressCreatedHandler : IEventHandler<AddressCreated>
    {
        private IMedParkRepository<Customer> _customerRepo { get; }
        private IMedParkRepository<CustomerAddress> _addressRepo { get; }

        public AddressCreatedHandler(IMedParkRepository<Customer> customerRepo, IMedParkRepository<CustomerAddress> addressRepo)
        {
            _customerRepo = customerRepo;
            _addressRepo = addressRepo;
        }

        public async Task HandleAsync(AddressCreated @event, ICorrelationContext context)
        {
            Customer customer = await _customerRepo.GetAsync(@event.UserId);

            if (customer is null)
                throw new MedParkException("order_customer_does_not_exists", $"Customer {@event.UserId} deos not exist.");


            CustomerAddress cAddr = new CustomerAddress(@event.Id);
            cAddr.SetAddress(@event.AddressLine1, @event.AddressLine2, @event.AddressLine3, @event.PostalCode);
            cAddr.SetAddressType(@event.AddressType);
            cAddr.SetCustomer(@event.UserId);

            cAddr.Use();

            await _addressRepo.AddAsync(cAddr);
        }
    }
}

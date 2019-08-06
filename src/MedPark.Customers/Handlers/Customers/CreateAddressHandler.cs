using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.Common.Types;
using MedPark.CustomersService.Domain;
using MedPark.CustomersService.Messages.Commands;
using MedPark.CustomersService.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.CustomersService.Handlers.Customers
{
    public class CreateAddressHandler : ICommandHandler<CreateAddress>
    {
        private IMedParkRepository<Customer> _customerRepo { get; }
        private IMedParkRepository<Address> _addressRepo { get; }
        private IBusPublisher _busPublisher;

        public CreateAddressHandler(IMedParkRepository<Customer> customerRepo, IMedParkRepository<Address> addressRepo, IBusPublisher busPublisher)
        {
            _customerRepo = customerRepo;
            _addressRepo = addressRepo;
            _busPublisher = busPublisher;
        }

        public async Task HandleAsync(CreateAddress command, ICorrelationContext context)
        {
            Customer customer = await _customerRepo.GetAsync(command.UserId);

            if (customer is null)
                throw new MedParkException("customer_does_not_create", $"Customer {command.UserId} does not exist.");

            Address addr = new Address(command.Id);
            addr.SetCustomer(command.UserId);
            addr.SetAddressType(command.AddressType);
            addr.SetAddress(command.AddressLine1, command.AddressLine2, command.AddressLine3, command.PostalCode);

            addr.Use();

            //save address
            await _addressRepo.AddAsync(addr);


            //Publish address created event
            AddressCreated addrCreated = new AddressCreated(command.Id, command.AddressLine1, command.AddressLine2, command.AddressLine3, command.PostalCode, command.AddressType, customer.Id);
            await _busPublisher.PublishAsync<AddressCreated>(addrCreated, null);
        }
    }
}

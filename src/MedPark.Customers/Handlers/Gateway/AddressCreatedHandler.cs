using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.CustomersService.Domain;
using MedPark.CustomersService.Messages.Events;
using MedPark.CustomersService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.CustomersService.Handlers.Gateway
{
    public class AddressCreatedHandler : IEventHandler<AddressCreated>
    {
        private readonly IAddressRepository _addressRepo;

        public AddressCreatedHandler(IAddressRepository addressRepo)
        {
            _addressRepo = addressRepo;
        }

        public async Task HandleAsync(AddressCreated command, ICorrelationContext context)
        {
            var address = await _addressRepo.GetAsync(x => x.Id == command.Id);

            if (address != null)
            {
                //Update address
                address.SetAddress(command.AddressLine1, command.AddressLine2, command.AddressLine3, command.PostalCode, command.AddressType);

                await _addressRepo.UpdateAsync(address);
            }
            else
            {
                address = new Address(command.Id, command.UserId);

                address.SetAddress(command.AddressLine1, command.AddressLine2, command.AddressLine3, command.PostalCode, command.AddressType);

                await _addressRepo.AddAsync(address);
            }
        }
    }
}

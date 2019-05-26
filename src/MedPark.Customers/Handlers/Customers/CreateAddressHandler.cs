using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.CustomersService.Domain;
using MedPark.CustomersService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.CustomersService.Messages.Commands
{
    public class CreateAddressHandler : ICommandHandler<CreateAddress>
    {
        private readonly IAddressRepository _addressRepo;

        public CreateAddressHandler(IAddressRepository addressRepo)
        {
            _addressRepo = addressRepo;
        }

        public async Task HandleAsync(CreateAddress command, ICorrelationContext context)
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
                address = new Address(Guid.NewGuid(), Guid.NewGuid());

                address.SetAddress(command.AddressLine1, command.AddressLine2, command.AddressLine3, command.PostalCode, command.AddressType);

                await _addressRepo.AddAsync(address);
            }
        }
    }
}

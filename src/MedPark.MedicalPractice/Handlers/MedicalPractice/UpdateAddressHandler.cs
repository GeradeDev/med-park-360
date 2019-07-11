using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.Common.Types;
using MedPark.MedicalPractice.Domain;
using MedPark.MedicalPractice.Messages.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Handlers.MedicalPractice
{
    public class UpdateAddressHandler : ICommandHandler<UpdateAddress>
    {
        private IMedParkRepository<Address> _addressRepo { get; }

        public UpdateAddressHandler(IMedParkRepository<Address> addressRepo)
        {
            _addressRepo = addressRepo;
        }
        
        public async Task HandleAsync(UpdateAddress command, ICorrelationContext context)
        {
            Address pracAddrs = await _addressRepo.GetAsync(command.Id);

            if (pracAddrs == null)
                throw new MedParkException("practice_address_does_not_exist", $"address {command.Id} does not exists.");

            pracAddrs.AddressLine1 = command.AddressLine1;
            pracAddrs.AddressLine2 = command.AddressLine2;
            pracAddrs.AddressLine3 = command.AddressLine3;
            pracAddrs.PostalCode = command.PostalCode;

            pracAddrs.UpdatedModifiedDate();

            await _addressRepo.UpdateAsync(pracAddrs);
        }
    }
}

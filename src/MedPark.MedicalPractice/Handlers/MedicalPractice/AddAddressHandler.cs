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
    public class AddAddressHandler : ICommandHandler<AddAddress>
    {
        private IMedParkRepository<Address> _addressRepo { get; }

        public AddAddressHandler(IMedParkRepository<Address> addressRepo)
        {
            _addressRepo = addressRepo;
        }


        public async Task HandleAsync(AddAddress command, ICorrelationContext context)
        {
            Address pracAddrs = await _addressRepo.GetAsync(x => x.PracticeId == command.PracticeId);

            if (pracAddrs != null)
                throw new MedParkException("practice_address_already_exists", $"An address record for practice {command.PracticeId} already exists.");

            pracAddrs = new Address(command.Id)
            {
                AddressLine1 = command.AddressLine1,
                AddressLine2 = command.AddressLine2,
                AddressLine3 = command.AddressLine3,
                PostalCode = command.PostalCode,
                PracticeId = command.PracticeId
            };

            await _addressRepo.AddAsync(pracAddrs);
        }
    }
}

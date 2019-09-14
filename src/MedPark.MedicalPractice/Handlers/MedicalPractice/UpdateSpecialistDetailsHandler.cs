using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.Common.Types;
using MedPark.MedicalPractice.Domain;
using MedPark.MedicalPractice.Messages.Commands;
using MedPark.MedicalPractice.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Handlers.MedicalPractice
{
    public class UpdateSpecialistDetailsHandler : ICommandHandler<UpdateSpecialistDetails>
    {
        private IMedParkRepository<Specialist> _specialistRepo { get; }
        private IBusPublisher _busPublisher { get; }

        public UpdateSpecialistDetailsHandler(IMedParkRepository<Specialist> specialistRepo, IBusPublisher busPublisher)
        {
            _specialistRepo = specialistRepo;
            _busPublisher = busPublisher;
        }

        public async Task HandleAsync(UpdateSpecialistDetails command, ICorrelationContext context)
        {
            Specialist specialist = await _specialistRepo.GetAsync(command.Id);

            if (specialist is null)
                throw new MedParkException("specilaist_does_not_exist", $"Specialist {command.Id} cannot be updated because it does not ecxist.");

            specialist.Create(command.FirstName, command.Surname, command.Email, command.Title);
            specialist.SetCellphone(command.Cellphone);
            specialist.UpdatedModifiedDate();

            //Update specialist details
            await _specialistRepo.UpdateAsync(specialist);

            //Publish specilaist updated event
            await _busPublisher.PublishAsync<SpecialistDetailsUpdated>(new SpecialistDetailsUpdated(command.Id, command.Title, command.FirstName, command.Surname, command.Email, command.Cellphone), CorrelationContext.Empty);
        } 
    }
}
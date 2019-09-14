using MedPark.Bookings.Domain;
using MedPark.Bookings.Messages.Events;
using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Handlers.MedicalPractice
{
    public class SpecialistDetailsUpdatedHandler : IEventHandler<SpecialistDetailsUpdated>
    {
        private IMedParkRepository<Specialist> _specialistRepo { get; }

        public SpecialistDetailsUpdatedHandler(IMedParkRepository<Specialist> specialistRepo)
        {
            _specialistRepo = specialistRepo;

        }

        public async Task HandleAsync(SpecialistDetailsUpdated @event, ICorrelationContext context)
        {
            Specialist specialist = await _specialistRepo.GetAsync(@event.Id);

            if (specialist is null)
                throw new MedParkException("specilaist_does_not_exist", $"Specialist {@event.Id} cannot be updated because it does not ecxist.");

            specialist.Create(@event.FirstName, @event.Surname, @event.Email, @event.Title);
            specialist.UpdatedModifiedDate();

            //Update specialist details
            await _specialistRepo.UpdateAsync(specialist);
        }
    }
}

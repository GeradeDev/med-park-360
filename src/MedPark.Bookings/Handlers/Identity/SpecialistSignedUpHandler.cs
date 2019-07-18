using MedPark.Bookings.Domain;
using MedPark.Bookings.Messages.Events;
using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Handlers.Identity
{
    public class SpecialistSignedUpHandler : IEventHandler<SpecialistSignedUp>
    {
        private IMedParkRepository<Specialist> _specialistRepo { get; }

        public SpecialistSignedUpHandler(IMedParkRepository<Specialist> specialistRepo)
        {
            _specialistRepo = specialistRepo;
        }

        public async Task HandleAsync(SpecialistSignedUp @event, ICorrelationContext context)
        {
            Specialist specialist = new Specialist(@event.Id);

            specialist.Create(@event.FirstName, @event.Surname, @event.Email);
            specialist.SignUp(@event.PracticeId);

            await _specialistRepo.AddAsync(specialist);
        }
    }
}

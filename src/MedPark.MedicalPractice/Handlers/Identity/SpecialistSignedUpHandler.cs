using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.MedicalPractice.Domain;
using MedPark.MedicalPractice.Messages.Events;
using MedPark.MedicalPractice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Handlers.Identity
{
    public class SpecialistSignedUpHandler : IEventHandler<SpecialistSignedUp>
    {
        private ISpeclialistRepository _specialistRepo { get; }

        public SpecialistSignedUpHandler(ISpeclialistRepository specialistRepo)
        {
            _specialistRepo = specialistRepo;
        }

        public async Task HandleAsync(SpecialistSignedUp @event, ICorrelationContext context)
        {
            Specialist specialist = new Specialist(@event.Id);

            specialist.Create(@event.FirstName, @event.Surname, @event.Email);

            await _specialistRepo.AddAsync(specialist);
        }
    }
}

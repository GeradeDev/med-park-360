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
    public class RemoveAcceptedMedicalSchemeHandler : ICommandHandler<RemoveAcceptedMedicalScheme>
    {
        private IMedParkRepository<AcceptedMedicalScheme> _medSchemeRepo { get; }

        public RemoveAcceptedMedicalSchemeHandler(IMedParkRepository<AcceptedMedicalScheme> medSchemeRepo)
        {
            _medSchemeRepo = medSchemeRepo;
        }

        public async Task HandleAsync(RemoveAcceptedMedicalScheme command, ICorrelationContext context)
        {
            AcceptedMedicalScheme acceptedScheme = await _medSchemeRepo.GetAsync(command.Id);
            if (acceptedScheme == null)
                throw new MedParkException("accepted_scheme_does_not_exist", $"The accepted scheme {command.Id} does not exist.");

            await _medSchemeRepo.DeleteAsync(command.Id);
        }
    }
}

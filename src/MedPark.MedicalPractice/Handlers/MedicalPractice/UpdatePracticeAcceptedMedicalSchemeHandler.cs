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
    public class UpdatePracticeAcceptedMedicalSchemeHandler : ICommandHandler<UpdatePracticeAcceptedMedicalScheme>
    {
        private IMedParkRepository<AcceptedMedicalScheme> _acceptedSchemesRepo { get; }
        private IMedParkRepository<MedicalScheme> _schemesRepo { get; }

        public UpdatePracticeAcceptedMedicalSchemeHandler(IMedParkRepository<AcceptedMedicalScheme> acceptedSchemesRepo, IMedParkRepository<MedicalScheme> schemesRepo)
        {
            _acceptedSchemesRepo = acceptedSchemesRepo;
            _schemesRepo = schemesRepo;
        }

        public async Task HandleAsync(UpdatePracticeAcceptedMedicalScheme command, ICorrelationContext context)
        {
            AcceptedMedicalScheme acceptedScheme = await _acceptedSchemesRepo.GetAsync(x => x.Id == command.Id);
            if (acceptedScheme == null)
            {
                throw new MedParkException($"Accepted scheme ({command.Id}) does not exist.");
            }

            //Update values
            acceptedScheme.SchemeId = command.SchemeId;
            acceptedScheme.SchemeName = command.SchemeName;
            acceptedScheme.DateEffective = command.DateEffective;
            acceptedScheme.DateEnd = command.DateEnd;
            acceptedScheme.IsActive = command.IsActive;

            acceptedScheme.UpdatedModifiedDate();

            //Save updated accepted medical scheme for medical practice
            await _acceptedSchemesRepo.UpdateAsync(acceptedScheme);
        }
    }
}

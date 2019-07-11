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
    public class AddPracticeAcceptedMedicalSchemeHandler : ICommandHandler<AddPracticeAcceptedMedicalScheme>
    {
        private IMedParkRepository<AcceptedMedicalScheme> _acceptedSchemesRepo { get; }
        private IMedParkRepository<MedicalScheme> _schemesRepo { get; }

        public AddPracticeAcceptedMedicalSchemeHandler(IMedParkRepository<AcceptedMedicalScheme> acceptedSchemesRepo, IMedParkRepository<MedicalScheme> schemesRepo)
        {
            _acceptedSchemesRepo = acceptedSchemesRepo;
            _schemesRepo = schemesRepo;
        }

        public async Task HandleAsync(AddPracticeAcceptedMedicalScheme command, ICorrelationContext context)
        {
            MedicalScheme selectedScheme = await _schemesRepo.GetAsync(command.SchemeId);
            if(selectedScheme == null)
            {
                throw new MedParkException($"Invalid medical scheme Id ({command.SchemeId}) for new accepted scheme.");
            }

            AcceptedMedicalScheme acceptedScheme = new AcceptedMedicalScheme(command.Id)
            {
                PracticeId = command.PracticeId,
                SchemeId = command.SchemeId,
                SchemeName = command.SchemeName,
                DateEffective = command.DateEffective,
                DateEnd = command.DateEnd,
                IsActive = command.IsActive
            };

            //Save accepted medical scheme for medical practice
            await _acceptedSchemesRepo.AddAsync(acceptedScheme);
        }
    }
}

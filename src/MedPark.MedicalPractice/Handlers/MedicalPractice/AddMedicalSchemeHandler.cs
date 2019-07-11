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
    public class AddMedicalSchemeHandler : ICommandHandler<AddMedicalScheme>
    {
        private IMedParkRepository<MedicalScheme> _schemesRepo { get; }

        public AddMedicalSchemeHandler(IMedParkRepository<MedicalScheme> schemesRepo)
        {
            _schemesRepo = schemesRepo;
        }

        public async Task HandleAsync(AddMedicalScheme command, ICorrelationContext context)
        {
            MedicalScheme scheme = await _schemesRepo.GetAsync(x => x.SchemeName == command.SchemeName);
            if (scheme != null)
                throw new MedParkException("scheme_already_exists", $"Medical scheme with the name {command.SchemeName} already exists.");

            scheme = new MedicalScheme(command.Id)
            {
                SchemeName = command.SchemeName
            };

            await _schemesRepo.AddAsync(scheme);
        }
    }
}

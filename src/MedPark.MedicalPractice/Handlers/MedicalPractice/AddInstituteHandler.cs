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
    public class AddInstituteHandler : ICommandHandler<AddInstitute>
    {
        private IMedParkRepository<Institute> _instRepo { get; }

        public AddInstituteHandler(IMedParkRepository<Institute> instRepo)
        {
            _instRepo = instRepo;
        }

        public async Task HandleAsync(AddInstitute command, ICorrelationContext context)
        {
            Institute newInstitute = await _instRepo.GetAsync(x => x.Name == command.Name);
            if (newInstitute != null)
                throw new MedParkException("institute_name_already_exists", $"The institute with the name {command.Name} already exists.");

            newInstitute = new Institute(command.Id)
            {
                Name = command.Name
            };

            await _instRepo.AddAsync(newInstitute);
        }
    }
}

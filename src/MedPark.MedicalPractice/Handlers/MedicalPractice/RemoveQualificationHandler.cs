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
    public class RemoveQualificationHandler : ICommandHandler<RemoveQualification>
    {
        private IMedParkRepository<Qualifications> _qualificationsRepo { get; }

        public RemoveQualificationHandler(IMedParkRepository<Qualifications> qualificationsRepo)
        {
            _qualificationsRepo = qualificationsRepo;
        }

        public async Task HandleAsync(RemoveQualification command, ICorrelationContext context)
        {
            bool qualificationExists = await _qualificationsRepo.ExistsAsync(x => x.Id == command.Id);

            if (!qualificationExists)
                throw new MedParkException("qualification_does_not_Exist", $"The qualification {command.Id} does not exist.");

            await _qualificationsRepo.DeleteAsync(command.Id);
        }
    }
}

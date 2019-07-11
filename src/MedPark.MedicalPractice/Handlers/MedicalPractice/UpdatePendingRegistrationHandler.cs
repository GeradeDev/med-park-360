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
    public class UpdatePendingRegistrationHandler : ICommandHandler<UpdatePendingRegistration>
    {
        private IMedParkRepository<PendingRegistration> _regRepo { get; }

        public UpdatePendingRegistrationHandler(IMedParkRepository<PendingRegistration> regRepo)
        {
            _regRepo = regRepo;
        }

        public async Task HandleAsync(UpdatePendingRegistration command, ICorrelationContext context)
        {
            PendingRegistration pendReg = await _regRepo.GetAsync(command.Id);

            if (pendReg == null)
                throw new MedParkException("specialist_registration_does_not_exists", $"The pending registration with Id {command.Id} does not exists.");

            pendReg.FirstName = command.FirstName;
            pendReg.LastName = command.LastName;
            pendReg.Email = command.Email;
            pendReg.Mobile = command.Mobile;
            pendReg.PracticeId = command.PracticeId;
            pendReg.IsAdmin = command.IsAdmin;

            pendReg.UpdatedModifiedDate();

            await _regRepo.UpdateAsync(pendReg);
        }
    }
}

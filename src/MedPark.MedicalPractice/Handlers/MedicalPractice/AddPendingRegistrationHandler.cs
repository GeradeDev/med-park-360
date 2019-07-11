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
    public class AddPendingRegistrationHandler : ICommandHandler<AddPendingRegistration>
    {
        private IMedParkRepository<PendingRegistration> _regRepo { get; }

        public AddPendingRegistrationHandler(IMedParkRepository<PendingRegistration> regRepo)
        {
            _regRepo = regRepo;
        }

        public async Task HandleAsync(AddPendingRegistration command, ICorrelationContext context)
        {
            PendingRegistration pendingReg = await _regRepo.GetAsync(x => x.Email == command.Email && x.PracticeId == command.PracticeId);

            if (pendingReg != null)
                throw new MedParkException("specialist_registration_already_exists", $"Pending registration on practice {command.PracticeId} for specialist with email {command.Email} already exists.");

            //Generate a new OTP
            var otp = String.Empty.NewOTP(8);

            pendingReg = new PendingRegistration(command.Id)
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Mobile = command.Mobile,
                PracticeId = command.PracticeId,
                IsAdmin = command.IsAdmin,
                OTP = otp
            };

            await _regRepo.AddAsync(pendingReg);
        }
    }
}

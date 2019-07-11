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
    public class AddQualificationHandler : ICommandHandler<AddQualification>
    {
        private IMedParkRepository<Qualifications> _qualificationsRepo {get;}
        private IMedParkRepository<Institute> _institutessRepo { get; }

        public AddQualificationHandler(IMedParkRepository<Qualifications> qualificationsRepo, IMedParkRepository<Institute> institutessRepo)
        {
            _qualificationsRepo = qualificationsRepo;
            _institutessRepo = institutessRepo;
        }

        public async Task HandleAsync(AddQualification command, ICorrelationContext context)
        {
            Institute institute = await _institutessRepo.GetAsync(command.InstituteId);

            if (institute == null)
                throw new MedParkException("qualification_institute_does_not_Exist", $"The institute {command.Id } does not exist.");


            Qualifications q = new Qualifications(command.Id)
            {
                InstituteId = command.InstituteId,
                QualificationName = command.QualificationName,
                YearObtained = command.YearObtained,
                CredentialId = command.CredentialId
            };

            await _qualificationsRepo.AddAsync(q);
        }
    }
}

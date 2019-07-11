using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Messages.Commands
{
    public class AddQualification : ICommand
    {
        public Guid Id { get; }
        public string QualificationName { get;}
        public Guid InstituteId { get;}
        public DateTime YearObtained { get;}

        public Guid CredentialId { get;}

        [JsonConstructor]
        public AddQualification(Guid id, string qualificationName, Guid instituteId, DateTime yearObtained, Guid credentialId)
        {
            Id = id;
            QualificationName = qualificationName;
            InstituteId = instituteId;
            YearObtained = yearObtained;
            CredentialId = credentialId;
        }
    }
}

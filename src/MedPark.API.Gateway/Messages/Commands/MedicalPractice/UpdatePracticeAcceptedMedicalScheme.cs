using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.API.Gateway.Messages.Commands
{
    [MessageNamespace("medical-practice")]
    public class UpdatePracticeAcceptedMedicalScheme : ICommand
    {
        public Guid Id { get; }
        public string SchemeName { get; }
        public Guid SchemeId { get; }
        public Guid PracticeId { get; }
        public DateTime DateEffective { get; }
        public DateTime DateEnd { get; }
        public Boolean IsActive { get; }

        [JsonConstructor]
        public UpdatePracticeAcceptedMedicalScheme(Guid id, string schemeName, Guid schemeId, Guid practiceId, DateTime dateEffective, DateTime dateEnd, Boolean isActive)
        {
            Id = id;
            SchemeName = schemeName;
            SchemeId = schemeId;
            PracticeId = practiceId;
            DateEffective = dateEffective;
            DateEnd = dateEffective;
            IsActive = isActive;
        }
    }
}

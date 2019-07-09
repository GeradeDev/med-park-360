using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Messages.Commands
{
    public class AddPracticeAcceptedMedicalScheme : ICommand
    {
        public Guid Id { get; }
        public string SchemeName { get; }
        public Guid SchemeId { get; }
        public Guid PracticeId { get; }
        public DateTime DateEffective { get; }
        public DateTime DateEnd { get; }
        public Boolean IsActive { get; }

        [JsonConstructor]
        public AddPracticeAcceptedMedicalScheme(Guid id, string schemeName, Guid schemeId, Guid practiceId, DateTime dateEffective, DateTime dateEnd, Boolean isActive)
        {
            Id = id;
            SchemeName = schemeName;
            SchemeId = schemeId;
            PracticeId = practiceId;
            DateEffective = dateEffective;
            DateEnd = dateEnd;
            IsActive = isActive;
        }
    }
}

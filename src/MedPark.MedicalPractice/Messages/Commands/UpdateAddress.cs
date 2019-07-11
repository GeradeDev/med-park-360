using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Messages.Commands
{
    public class UpdateAddress : ICommand
    {
        public Guid Id { get; }
        public string AddressLine1 { get; }
        public string AddressLine2 { get; }
        public string AddressLine3 { get; }
        public string PostalCode { get; }
        public Guid PracticeId { get; }

        [JsonConstructor]
        public UpdateAddress(Guid id, string addressLine1, string addressLine2, string addressLine3, string postalCode, Guid practiceId)
        {
            Id = id;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            AddressLine3 = addressLine3;
            PostalCode = postalCode;
            PracticeId = practiceId;
        }
    }
}

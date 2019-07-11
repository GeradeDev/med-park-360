using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Messages.Commands
{
    public class RemoveQualification : ICommand
    {
        public Guid Id { get; }

        [JsonConstructor]
        public RemoveQualification(Guid id)
        {
            Id = id;
        }
    }
}

using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Messages.Commands
{
    public class RemoveAcceptedMedicalScheme : ICommand
    {
        public Guid Id { get; }

        [JsonConstructor]
        public RemoveAcceptedMedicalScheme(Guid id)
        {
            Id = id;
        }
    }
}

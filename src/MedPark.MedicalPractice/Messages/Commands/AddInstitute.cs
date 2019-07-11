using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Messages.Commands
{
    public class AddInstitute : ICommand
    {
        public Guid Id { get; }
        public string Name { get; }

        [JsonConstructor]
        public AddInstitute(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.API.Gateway.Messages.Commands
{
    [MessageNamespace("medical-practice")]
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

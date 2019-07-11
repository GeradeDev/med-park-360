﻿using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.API.Gateway.Messages.Commands
{
    [MessageNamespace("medical-practice")]
    public class AddMedicalScheme : ICommand
    {
        public Guid Id { get; }
        public string SchemeName { get; }

        [JsonConstructor]
        public AddMedicalScheme(Guid id, string schemeName)
        {
            Id = id;
            SchemeName = schemeName;
        }
    }
}

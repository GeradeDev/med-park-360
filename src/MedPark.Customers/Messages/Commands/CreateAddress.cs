using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.CustomersService.Messages.Commands
{
    public class CreateAddress : ICommand
    {
        public Guid Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public Int32 AddressType { get; set; }
        public string PostalCode { get; set; }
        public Guid UserId { get; set; }

        [JsonConstructor]
        public CreateAddress(Guid id, string line1, string line2, string line3, string postal, Int32 type, Guid userid)
        {
            Id = id;
            AddressLine1 = line1;
            AddressLine2 = line2;
            AddressLine3 = line3;
            PostalCode = postal;
            AddressType = type;

            UserId = userid;
        }
    }
}

using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.CustomersService.Domain
{
    public class Address : IIdentifiable
    {
        public Guid Id { get; set; }
        public DateTime Modified { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public Int32 AddressType { get; set; }

        public string PostalCode { get; set; }
        public Guid UserId { get; set; }

        public Address(Guid id, Guid userId)
        {
            Id = id;
            UserId = userId;
        }

        public void SetAddress(string line1, string line2, string line3, string postalCode, Int32 type)
        {
            AddressLine1 = line1;
            AddressLine2 = line2;
            AddressLine3 = line3;
            PostalCode = postalCode;
            AddressType = type;

            Modified = DateTime.Now;
        }
    }
}

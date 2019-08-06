using MedPark.Common;
using MedPark.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.CustomersService.Domain
{
    public class Address : BaseIdentifiable
    {
        public Address(Guid id) : base(id)
        {
        }

        public string AddressLine1 { get; private set; }
        public string AddressLine2 { get; private set; }
        public string AddressLine3 { get; private set; }
        public Int32 AddressType { get; private set; }
        public string PostalCode { get; private set; }
        public Guid UserId { get; private set; }
        
        public void SetCustomer(Guid customerId)
        {
            UserId = customerId;
        }

        public void SetAddress(string line1, string line2, string line3, string postalCode)
        {
            AddressLine1 = line1;
            AddressLine2 = line2;
            AddressLine3 = line3;
            PostalCode = postalCode;
        }

        public void SetAddressType(Int32 type)
        {
            AddressType = type;
        }

        public override void Use()
        {
            if (string.IsNullOrEmpty(AddressLine1) || string.IsNullOrEmpty(AddressLine2) || string.IsNullOrEmpty(PostalCode))
                throw new MedParkException("invaid_Address", "One or more of the address details are not valid.");

            UpdatedModified();
        }
    }
}

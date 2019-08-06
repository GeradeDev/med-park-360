using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.OrderService.Domain
{
    public class CustomerAddress : BaseIdentifiable
    {
        public CustomerAddress(Guid id) : base(id)
        {

        }

        public string AddressLine1 { get; private set; }
        public string AddressLine2 { get; private set; }
        public string AddressLine3 { get; private set; }
        public Int32 AddressType { get; private set; }

        public string PostalCode { get; private set; }
        public Guid CustomerId { get; private set; }
        public bool? IsPickUpLocation { get; private set; }

        public void SetCustomer(Guid customerId)
        {
            CustomerId = customerId;
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

        public void IsPickupLocation(bool pickupLocation)
        {
            IsPickUpLocation = pickupLocation;
        }

        public override void Use()
        {
            UpdatedModified();
        }
    }
}

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

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public Int32 AddressType { get; set; }

        public string PostalCode { get; set; }
        public Guid CustomerId { get; set; }
        public bool? IsPickUpLocation { get; set; }
    }
}

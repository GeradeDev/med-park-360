using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Domain
{
    public class Address : BaseIdentifiable
    {
        public Address(Guid id) : base(id)
        {

        }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string PostalCode { get; set; }
        public Guid PracticeId { get; set; }

        public void UpdatedModifiedDate()
            => UpdatedModified();
    }
}

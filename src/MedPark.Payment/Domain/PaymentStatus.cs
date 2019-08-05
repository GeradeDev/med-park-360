using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Payment.Domain
{
    public class PaymentStatus : BaseIdentifiable
    {
        public PaymentStatus(Guid id) : base(id)
        {

        }

        public string Name { get; private set; }

        public void SetStatus(string name)
        {
            Name = name;
        }
    }
}

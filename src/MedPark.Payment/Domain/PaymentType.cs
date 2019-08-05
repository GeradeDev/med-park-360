using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Payment.Domain
{
    public class PaymentType : BaseIdentifiable
    {
        public PaymentType(Guid id) : base(id)
        {

        }

        public string Name { get; private set; }

        public void SetPaymentMethod(string name)
        {
            Name = name;
        }
    }
}

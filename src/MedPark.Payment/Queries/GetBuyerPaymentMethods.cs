using MedPark.Payment.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedPark.Common.Types;

namespace MedPark.Payment.Queries
{
    public class GetBuyerPaymentMethods : IQuery<IEnumerable<PaymentMethodDto>>
    {
        public Guid CustomerId { get; set; }
    }
}

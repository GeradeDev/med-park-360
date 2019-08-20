using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Web.Models.PaymentService
{
    public class PaymentMethodDto
    {
        public Guid PaymentMethodId { get; set; }
        public Guid PaymentTypeId { get; set; }
        public int PaymentCardType { get; set; }
        public string PaymentCardNumber { get; set; }
        public DateTime? PaymentCardExpiry { get; set; }
        public string PaymentType { get; set; }
    }
}

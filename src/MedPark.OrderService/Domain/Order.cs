using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.OrderService.Domain
{
    public class Order : BaseIdentifiable
    {
        public Order(Guid id) : base(id)
        {
            DatePlaced = DateTime.UtcNow;

            this.LineItems = new HashSet<LineItem>();
        }

        public Guid CustomerId { get; private set; }
        public string OrderNo { get; private set; }
        public DateTime DatePlaced { get; private set; }
        public DateTime? DatePaid { get; private set; }
        public decimal OrderTotal { get; private set; }
        public decimal TotalVat { get; private set; }
        public int? ShippingType { get; private set; }
        public Guid? ShippingAddress { get; private set; }
        public int OrderStatus { get; private set; }
        public string Comments { get; private set; }
        public Guid? PaymentMethod { get; private set; }

        public virtual ICollection<LineItem> LineItems { get; set; }

        public void CreateNewOrder(Guid customerId, string orderNo, int status)
        {
            CustomerId = customerId;
            OrderNo = orderNo;
            OrderStatus = status;
        }

        public void SetOrderTotal(decimal orderTotal)
        {
            OrderTotal = orderTotal;

            CalculateVat();
            UpdatedModified();
        }

        private void CalculateVat()
        {
            TotalVat = (OrderTotal * (decimal)0.14);
        }

        public void SetShipping(int shippingType, Guid shippingAddress)
        {
            ShippingType = shippingType;
            ShippingAddress = shippingAddress;
            UpdatedModified();
        }

        public void SetOrderComment(string comment)
        {
            Comments = comment;
            UpdatedModified();
        }

        public void SetPaymentMethod(Guid method)
        {
            PaymentMethod = method;
        }
    }
}

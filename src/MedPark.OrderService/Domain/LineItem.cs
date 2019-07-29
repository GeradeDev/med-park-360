using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.OrderService.Domain
{
    public class LineItem : BaseIdentifiable
    {
        public LineItem(Guid id) : base(id)
        {

        }

        public Guid OrderId { get; private set; }
        public string ProductCode { get; private set; }
        public string ProductName { get; private set; }
        public string ProductDescription { get; private set; }
        public int Quantity { get; private set; }
        public int Markup { get; private set; }
        public decimal Price { get; private set; }
        public string NappiCode { get; private set; }
    }
}

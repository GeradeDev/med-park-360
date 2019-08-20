using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Web.Models.OrderService
{
    public class LineItemDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Quantity { get; set; }
        public int Markup { get; set; }
        public decimal Price { get; set; }
        public string NappiCode { get; set; }
    }
}

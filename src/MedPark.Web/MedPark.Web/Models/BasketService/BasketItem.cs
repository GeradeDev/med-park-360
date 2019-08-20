using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Web.Models.BasketService
{
    public class BasketItem
    {
        public Guid Id { get; set; }
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
        public string Code { get; set; }
        public string Name { get;  set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}

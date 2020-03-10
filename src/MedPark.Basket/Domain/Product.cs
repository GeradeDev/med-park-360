using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Basket.Domain
{
    public class Product : BaseIdentifiable
    {
        public Product(Guid id) : base(id)
        {
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }
    }
}

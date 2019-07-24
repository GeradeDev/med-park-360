using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Catalog.Domain
{
    public class Product : BaseIdentifiable
    {
        public Product(Guid id) : base(id)
        {
        }

        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Available { get; private set; }
        public int AvailableQuantity { get; private set; }
        public bool HasMarkup { get; private set; }
        public int Markup { get; private set; }
        public decimal Price { get; private set; }
        public string NappiCode { get; private set; }
    }
}

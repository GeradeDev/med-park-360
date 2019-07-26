using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Catalog.Dto
{
    public class ProductDetailDto
    {
        public Guid Id { get; set; }
        public DateTime Modified { get; set; }

        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int AvailableQuantity { get; private set; }
        public decimal Price { get; private set; }
        public string NappiCode { get; private set; }

        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}

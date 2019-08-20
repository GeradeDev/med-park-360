using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Web.Models.Catalog
{
    public class ProductDetailDto
    {
        public Guid Id { get; set; }
        public DateTime Modified { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal Price { get; set; }
        public string NappiCode { get; set; }

        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Web.Models.Catalog
{
    public class CategoryDetailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentCategory { get; set; }

        public IEnumerable<ProductDetailDto> Products { get; set; }
    }
}

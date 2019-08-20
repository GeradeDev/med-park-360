using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Web.Models.Catalog
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public DateTime Modified { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ParentCategory { get; set; }
    }
}

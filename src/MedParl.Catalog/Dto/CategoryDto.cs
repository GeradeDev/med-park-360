using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Catalog.Dto
{
    public class CategoryDto
    {
        public Guid Id { get; protected set; }
        public DateTime Modified { get; protected set; }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid? ParentCategory { get; private set; }
    }
}

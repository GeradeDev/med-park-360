using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Catalog.Domain
{
    public class Category : BaseIdentifiable
    {
        public Category(Guid id) : base(id)
        {

        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Available { get; private set; }
        public Guid? ParentCategory { get; private set; }
    }
}

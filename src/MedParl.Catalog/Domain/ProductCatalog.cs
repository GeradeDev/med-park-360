using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Catalog.Domain
{
    public class ProductCatalog : BaseIdentifiable
    {
        public ProductCatalog(Guid id) : base(id)
        {

        }

        public Guid ProductId { get; private set; }
        public Guid CategoryId { get; private set; }
    }
}

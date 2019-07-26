using MedPark.Catalog.Dto;
using MedPark.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Catalog.Queries
{
    public class CategoryQueries : IQuery<CategoryDto>, IQuery<CategoryDetailDto>
    {
        public Guid CategoryId { get; set; }
    }
}

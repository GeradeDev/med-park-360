﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.API.Gateway.Models.Catalog
{
    public class CatalogDetailDto
    {
        public IEnumerable<CategoryDto> Categories { get; set; }
        public IEnumerable<ProductDetailDto> Products { get; set; }
    }
}

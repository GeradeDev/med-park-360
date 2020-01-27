using AutoMapper;
using MedPark.Catalog.Domain;
using MedPark.Catalog.Dto;
using MedPark.Catalog.Queries;
using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Catalog.Handlers.Catalog
{
    public class ProductQueriesHandler : IQueryHandler<ProductQueries, ProductDetailDto>
    {
        private IMedParkRepository<Product> _productsRepo { get; }
        private IMedParkRepository<ProductCatalog> _catalogRepo { get; }
        private IMedParkRepository<Category> _categoryRepo { get; }

        private IMapper _mapper { get; }

        public ProductQueriesHandler(IMedParkRepository<Product> productsRepo, IMapper mapper, IMedParkRepository<ProductCatalog> catalogRepo, IMedParkRepository<Category> categoryRepo)
        {
            _productsRepo = productsRepo;
            _mapper = mapper;
            _catalogRepo = catalogRepo;
            _categoryRepo = categoryRepo;
        }

        public async Task<ProductDetailDto> HandleAsync(ProductQueries query)
        {
            Product prod = await _productsRepo.GetAsync(query.ProductId);

            if (prod is null)
                throw new MedParkException("product_does_not_exist", $"Product with Id {query.ProductId} does not exist.");

            var dto =  _mapper.Map<ProductDetailDto>(prod);

            ProductCatalog pc = await _catalogRepo.GetAsync(x => x.ProductId == prod.Id);

            Category cat = await _categoryRepo.GetAsync(pc.CategoryId);

            dto.CategoryId = cat.Id;
            dto.CategoryName = cat.Name;

            return dto;
        }
    }
}

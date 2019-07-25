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
        private IMapper _mapper { get; }

        public ProductQueriesHandler(IMedParkRepository<Product> productsRepo, IMapper mapper)
        {
            _productsRepo = productsRepo;
            _mapper = mapper;
        }

        public async Task<ProductDetailDto> HandleAsync(ProductQueries query)
        {
            Product prod = await _productsRepo.GetAsync(query.ProductId);

            if (prod is null)
                throw new MedParkException("product_does_not_exist", $"Product with Id {query.ProductId} does not exist.");

            return _mapper.Map<ProductDetailDto>(prod);
        }
    }
}

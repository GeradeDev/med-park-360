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
    public class GetCategoryDetailsHandler : IQueryHandler<CategoryQueries, CategoryDetailDto>
    {
        private IMedParkRepository<Product> _productsRepo { get; }
        private IMedParkRepository<ProductCatalog> _catalogRepo { get; }
        private IMedParkRepository<Category> _categoryRepo { get; }

        private IMapper _mapper { get; }

        public GetCategoryDetailsHandler(IMedParkRepository<Product> productsRepo, IMapper mapper, IMedParkRepository<ProductCatalog> catalogRepo, IMedParkRepository<Category> categoryRepo)
        {
            _productsRepo = productsRepo;
            _mapper = mapper;
            _catalogRepo = catalogRepo;
            _categoryRepo = categoryRepo;
        }

        public async Task<CategoryDetailDto> HandleAsync(CategoryQueries query)
        {
            Category cat = await _categoryRepo.GetAsync(query.CategoryId);

            if (cat is null)
                throw new MedParkException("category_does_not_exist", $"The category { query.CategoryId} does not exist.");

            CategoryDetailDto categoryDetails = _mapper.Map<CategoryDetailDto>(cat);

            var catProducts = (from c in await _categoryRepo.GetAllAsync()
                               join pc in await _catalogRepo.GetAllAsync() on c.Id equals pc.CategoryId
                               join prod in await _productsRepo.GetAllAsync() on pc.ProductId equals prod.Id
                               select prod).ToList();

            categoryDetails.Products = _mapper.Map<List<ProductDetailDto>>(catProducts);

            return categoryDetails;
        }
    }
}

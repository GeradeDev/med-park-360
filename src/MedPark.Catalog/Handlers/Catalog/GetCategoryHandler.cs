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
    public class GetCategoryHandler : IQueryHandler<CategoryQueries, CategoryDto>
    {
        private IMedParkRepository<Category> _categoryRepo { get; }

        private IMapper _mapper { get; }

        public GetCategoryHandler(IMedParkRepository<Category> categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<CategoryDto> HandleAsync(CategoryQueries query)
        {
            Category cat = await _categoryRepo.GetAsync(query.CategoryId);

            if (cat is null)
                throw new MedParkException("category_does_not_exist", $"The category { query.CategoryId} does not exist.");

            return _mapper.Map<CategoryDto>(cat);
        }
    }
}

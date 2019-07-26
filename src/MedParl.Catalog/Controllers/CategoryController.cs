using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedPark.Catalog.Dto;
using MedPark.Catalog.Queries;
using MedPark.Common.Dispatchers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedPark.Catalog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IDispatcher _dispatcher { get; }

        public CategoryController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }


        [HttpGet("{categoryid}")]
        public async Task<IActionResult> Get([FromRoute] CategoryQueries query)
        {
            CategoryDto category = await _dispatcher.QueryAsync<CategoryDto>(query);

            return Ok(category);
        }

        [HttpGet("{categoryid}/details/")]
        public async Task<IActionResult> GetCategoryDetails([FromRoute] CategoryQueries query)
        {
            CategoryDetailDto categoryInFull = await _dispatcher.QueryAsync<CategoryDetailDto>(query);

            return Ok(categoryInFull);
        }
    }
}
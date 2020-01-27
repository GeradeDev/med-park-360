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
    public class CatalogController : ControllerBase
    {
        private IDispatcher _dispatcher { get; }
        public CatalogController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }


        [HttpGet("")]
        public async Task<IActionResult> Get([FromRoute] CatalogQuery query)
        {
            CatalogDetailDto category = await _dispatcher.QueryAsync<CatalogDetailDto>(query);

            return Ok(category);
        }

        [HttpGet("{parentcategoryid}")]
        public async Task<IActionResult> GetCategoryDetails([FromRoute] CatalogQuery query)
        {
            CatalogDetailDto categoryInFull = await _dispatcher.QueryAsync<CatalogDetailDto>(query);

            return Ok(categoryInFull);
        }
    }
}
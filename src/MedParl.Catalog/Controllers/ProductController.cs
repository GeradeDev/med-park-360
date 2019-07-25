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
    public class ProductController : ControllerBase
    {
        private IDispatcher _dispatcher { get; }

        public ProductController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }


        [HttpGet("{productid}")]
        public async Task<IActionResult> Get([FromRoute] ProductQueries query)
        {
            ProductDetailDto product = await _dispatcher.QueryAsync(query);

            return Ok(product);
        }
    }
}
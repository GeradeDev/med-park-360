using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedPark.API.Gateway.Models.Catalog;
using MedPark.API.Gateway.Services;
using MedPark.Common;
using MedPark.Common.Cache;
using MedPark.Common.RabbitMq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedPark.API.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private IBusPublisher _busPublisher { get; set; }
        private ICatalogService _catalogService { get; set; }

        public CatalogController(IBusPublisher busPublisher, ICatalogService catalogService)
        {
            _busPublisher = busPublisher;
            _catalogService = catalogService;
        }

        [HttpGet("fullcatalog")]
        [Cached(Constants.Day_In_Seconds)]
        public async Task<IActionResult> GetCatalog()
        {
            CatalogDetailDto catalog = await _catalogService.GetFullCatalog();

            return Ok(catalog);
        }

        [HttpGet("catalogByCategory/{parentcategoryid}")]
        [Cached(Constants.Day_In_Seconds)]
        public async Task<IActionResult> GetCatalogByCategory(Guid parentcategoryid)
        {
            CatalogDetailDto category = await _catalogService.GetCatalogByCategoryId(parentcategoryid);

            return Ok(category);
        }



        [HttpGet("category/{categoryid}/")]
        [Cached(Constants.Day_In_Seconds)]
        public async Task<IActionResult> GetCategory([FromRoute] Guid categoryid)
        {
            CategoryDto category = await _catalogService.GetCategoryById(categoryid);

            return Ok(category);
        }

        [HttpGet("category/{categoryid}/details")]
        [Cached(Constants.Day_In_Seconds)]
        public async Task<IActionResult> GetCategoryDetails([FromRoute] Guid categoryid)
        {
            CategoryDetailDto categoryDetails = await _catalogService.GetCategoryByIdDetails(categoryid);

            return Ok(categoryDetails);
        }




        [HttpGet("product/{productid}")]
        [Cached(Constants.Day_In_Seconds)]
        public async Task<IActionResult> GetProduct([FromRoute] Guid productid)
        {
            ProductDetailDto product = await _catalogService.GetProductById(productid);

            return Ok(product);
        }
    }
}
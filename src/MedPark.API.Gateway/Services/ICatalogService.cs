using MedPark.API.Gateway.Models.Catalog;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.API.Gateway.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface ICatalogService
    {
        //CATEGORIES
        [Get("/category/{categoryid}")]
        Task<CategoryDto> GetCategoryById([Path] Guid categoryid);

        [Get("/category/{categoryid}/details/")]
        Task<CategoryDetailDto> GetCategoryByIdDetails([Path] Guid categoryid);


        //PRODUCTS
        [Get("/product/{productid}")]
        Task<ProductDetailDto> GetProductById([Path] Guid productid);


        //CATALOG
        [Get("/catalog/")]
        Task<CatalogDetailDto> GetFullCatalog();

        [Get("/catalog/{parentcategoryid}")]
        Task<CatalogDetailDto> GetCatalogByCategoryId([Path] Guid parentcategoryid);
    }
}

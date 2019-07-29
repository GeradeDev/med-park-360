using MedPark.API.Gateway.Models.BasketService;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.API.Gateway.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IBasketService
    {
        [Get("basket/{customerid}")]
        Task<BasketDto> GetBasketByCustomerId([Path] Guid customerid);
    }
}

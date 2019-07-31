using MedPark.API.Gateway.Models.OrderService;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.API.Gateway.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IOrderService
    {
        [Get("order/{orderid}")]
        Task<OrderDetailDto> GetOrderById([Path] Guid orderid);

        [Get("order/{orderid}/summary")]
        Task<OrderSummaryDto> GetOrderSummary([Path] Guid orderid);
    }
}

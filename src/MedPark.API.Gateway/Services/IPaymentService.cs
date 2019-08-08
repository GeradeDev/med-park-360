using MedPark.API.Gateway.Models.PaymentService;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.API.Gateway.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IPaymentService
    {
        [Get("payment/{customerid}")]
        Task<PaymentMethodDto> GetPaymentMethodsByCustomerId([Path] Guid customerid);
    }
}

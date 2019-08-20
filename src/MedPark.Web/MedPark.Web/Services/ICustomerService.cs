using MedPark.Web.Models;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Web.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface ICustomerService
    {
        [Get("api/customers/{id}")]
        Task<Customer> GetCustomer([Path] Guid id);

        [Get("api/address/{id}")]
        Task<List<Address>> GetAddreses([Path] Guid id);
    }
}

using MedPark.API.Gateway.Messages.Commands;
using MedPark.API.Gateway.Models;
using Microsoft.AspNetCore.Mvc;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.API.Gateway.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface ICustomerService
    {
        [Get("/customers/{id}")]
        Task<Customer> GetCustomer([Path] Guid id);

        [Get("/address/{id}")]
        Task<List<Address>> GetAddreses([Path] Guid id);
    }
}

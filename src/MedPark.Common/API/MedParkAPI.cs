using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MedPark.Common.API
{
    public class CustomersService
    {
        private readonly IHttpClientFactory _httpClient;
        private string _baseServiceUrl = "http://localhost:7000/api";

        public CustomersService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        

        public async Task<string> GetDetails(Guid customerId)
        {
            return await _httpClient.CreateClient().GetStringAsync($"{_baseServiceUrl}/customers/{ customerId }");
        }



        public async Task<string> GetAddresses(Guid customerId)
        {
            return await _httpClient.CreateClient().GetStringAsync($"{_baseServiceUrl} /address/ { customerId }");
        }

        public async Task<string> CreateUpdateAddresses(Guid customerId)
        {
            return await _httpClient.CreateClient().GetStringAsync($"{_baseServiceUrl} /address/ { customerId }");
        }
    }
}

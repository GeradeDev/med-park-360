using MedPark.Common.Types;
using MedPark.CustomersService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.CustomersService.Queries
{
    public class GetCustomerAddress : IQuery<List<AddressDto>>
    {
        public Guid Id { get; set; }
    }
}

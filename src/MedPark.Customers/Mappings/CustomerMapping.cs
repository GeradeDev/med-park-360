using AutoMapper;
using MedPark.CustomersService.Domain;
using MedPark.CustomersService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.CustomersService.Mappings
{
    public class CustomerMapping : Profile
    {
        public CustomerMapping()
        {
            CreateMap<CustomerDto, Customer>();
            CreateMap<AddressDto, Address>();
        }
    }
}

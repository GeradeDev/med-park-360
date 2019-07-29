using AutoMapper;
using MedPark.Basket.Domain;
using MedPark.Basket.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Mappings
{
    public class BookingServiceMappings : Profile
    {
        public BookingServiceMappings()
        {
            CreateMap<CustomerBasket, BasketDto>();
        }
    }
}

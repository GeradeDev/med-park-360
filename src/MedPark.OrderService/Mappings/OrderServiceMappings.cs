using AutoMapper;
using MedPark.OrderService.Domain;
using MedPark.OrderService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Mappings
{
    public class OrderServiceMappings : Profile
    {
        public OrderServiceMappings()
        {
            CreateMap<Order, OrderDetailDto>();
            CreateMap<Order, OrderSummaryDto>();
            CreateMap<LineItem, LineItemDto>();
        }
    }
}

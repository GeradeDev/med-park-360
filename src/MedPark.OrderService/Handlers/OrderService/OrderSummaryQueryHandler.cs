using AutoMapper;
using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.Types;
using MedPark.OrderService.Domain;
using MedPark.OrderService.Dto;
using MedPark.OrderService.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.OrderService.Handlers.OrderService
{
    public class OrderSummaryQueryHandler : IQueryHandler<OrderQuery, OrderSummaryDto>
    {
        private IMedParkRepository<Order> _orderRepo { get; }
        private IMapper _mapper { get; }

        public OrderSummaryQueryHandler(IMedParkRepository<Order> orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }

        public async Task<OrderSummaryDto> HandleAsync(OrderQuery query)
        {
            Order o = await _orderRepo.GetAsync(query.OrderId);

            if (o is null)
                throw new MedParkException("order_does_not_exist", $"Order {query.OrderId} does not exist.");

            return _mapper.Map<OrderSummaryDto>(o);
        }
    }
}

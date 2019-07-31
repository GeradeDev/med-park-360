using MedPark.OrderService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.Types;
using MedPark.OrderService.Queries;
using MedPark.OrderService.Domain;
using AutoMapper;

namespace MedPark.OrderService.Handlers.OrderService
{
    public class OrderQueryHandler : IQueryHandler<OrderQuery, OrderDetailDto>
    {
        private IMedParkRepository<Order> _orderRepo { get; }
        private IMedParkRepository<LineItem> _orderItemRepo { get; }
        private IMapper _mapper { get; }

        public OrderQueryHandler(IMedParkRepository<Order> orderRepo, IMedParkRepository<LineItem> orderItemRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _orderItemRepo = orderItemRepo;
            _mapper = mapper;
        }

        public async Task<OrderDetailDto> HandleAsync(OrderQuery query)
        {
            Order o = await _orderRepo.GetAsync(query.OrderId);

            if (o is null)
                throw new MedParkException("order_does_not_exist", $"Order {query.OrderId} does not exist.");

            OrderDetailDto resultDto = _mapper.Map<OrderDetailDto>(o);

            IEnumerable<LineItem> lineItems = await _orderItemRepo.FindAsync(x => x.OrderId == query.OrderId);
            List<LineItemDto> liDtos = new List<LineItemDto>();

            lineItems.ToList().ForEach(li =>
            {
                LineItemDto liDto = _mapper.Map<LineItemDto>(li);
                liDtos.Add(liDto);
            });

            resultDto.OrderItems = liDtos;

            return resultDto;
        }
    }
}

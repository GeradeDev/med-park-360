using MedPark.Common.Types;
using MedPark.OrderService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.OrderService.Queries
{
    public class OrderQuery : IQuery<OrderSummaryDto>, IQuery<OrderDetailDto>
    {
        public Guid OrderId { get; set; }
    }
}

using MedPark.Basket.Dto;
using MedPark.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Basket.Queries
{
    public class BasketQuery : IQuery<BasketDto>
    {
        public Guid CustomerId { get; set; }
    }
}

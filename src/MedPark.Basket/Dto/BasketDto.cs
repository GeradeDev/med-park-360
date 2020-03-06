using MedPark.Basket.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Basket.Dto
{
    public class BasketDto
    {
        public Guid BasketId { get; set; }
        public DateTime Modified { get; set; }
        public IEnumerable<BasketItemDto> Items { get; set; }
        public decimal BasketTotal { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Web.Models.BasketService
{
    public class BasketDto
    {
        public Guid BasketId { get; set; }
        public DateTime Modified { get; set; }
        public IEnumerable<BasketItem> Items { get; set; }
        public decimal BasketTotal { get; set; }
    }
}

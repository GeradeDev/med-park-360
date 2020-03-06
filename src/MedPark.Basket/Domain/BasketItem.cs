using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Basket.Domain
{
    public class BasketItem : BaseIdentifiable
    {
        public BasketItem(Guid id) : base(id)
        {

        }

        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public void UpdatedModifiedDate()
            => UpdatedModified();

        public void UpdateQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}

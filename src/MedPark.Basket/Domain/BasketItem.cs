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

        public Guid BasketId { get; private set; }
        public Guid ProductId { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        public void UpdatedModifiedDate()
            => UpdatedModified();

        public void UpdateQuatity(int quantity)
        {
            Quantity = quantity;
        }
    }
}

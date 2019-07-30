using MedPark.Basket.Domain;
using MedPark.Common.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Basket.Messaging.Events
{

    public class BasketCheckedOut : IEvent
    {
        public Guid CustomerId { get; set; }
        public IEnumerable<BasketItem> Items { get; set; }

        [JsonContructor]
        public BasketCheckedOut(Guid buyerId)
        {
            CustomerId = buyerId;
        }
    }
}

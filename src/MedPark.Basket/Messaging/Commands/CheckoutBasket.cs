using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Basket.Messaging.Commands
{
    public class CheckoutBasket : ICommand
    {
        public Guid BasketId { get; private set; }

        [JsonConstructor]
        public CheckoutBasket(Guid basketId)
        {
            BasketId = basketId;
        }
    }
}

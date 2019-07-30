using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.API.Gateway.Messages.Commands.BasketService
{
    [MessageNamespace("basket-service")]
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

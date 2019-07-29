using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.API.Gateway.Messages.Commands.BasketService
{
    [MessageNamespace("basket-service")]
    public class CreateBasket : ICommand
    {
        public Guid BasketId { get; private set; }
        public Guid BuyerId { get; private set; }

        [JsonConstructor]
        public CreateBasket(Guid basketId, Guid buyerId)
        {
            BasketId = basketId;
            BuyerId = buyerId;
        }
    }
}

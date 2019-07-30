using MedPark.Basket.Domain;
using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Basket.Messaging.Commands
{
    public class AddProductToBasket : ICommand
    {
        public Guid BasketId { get; }
        public BasketItem Item { get; }

        [JsonConstructor]
        public AddProductToBasket(Guid basketId, BasketItem item)
        {
            BasketId = basketId;
            Item = item;
        }
    }
}

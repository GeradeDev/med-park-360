using MedPark.API.Gateway.Models.BasketService;
using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.API.Gateway.Messages.Commands.BasketService
{
    [MessageNamespace("basket-service")]
    public class UpdateBasket : ICommand
    {
        public Guid BasketId { get; private set; }
        public IEnumerable<BasketItem> Items { get; private set; }

        [JsonConstructor]
        public UpdateBasket(Guid basketId, IEnumerable<BasketItem> items)
        {
            BasketId = basketId;
            Items = items;
        }
    }
}

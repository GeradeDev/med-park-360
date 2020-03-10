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
    public class AddProductToBasket : ICommand
    {
        public Guid BasketItemtId { get; }

        public Guid BasketId { get; }
        public Guid ProductId { get; }
        public int Quantity { get; }

        [JsonConstructor]
        public AddProductToBasket(Guid basketItemtId, Guid basketId, Guid productId, int quantity)
        {
            BasketItemtId = basketItemtId;
            BasketId = basketId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}

﻿using MedPark.Common.Messages;
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
        public int ShippingType { get; private set; }
        public Guid ShippingAddress { get; private set; }

        [JsonConstructor]
        public CheckoutBasket(Guid basketId, int shippingType, Guid shippingAddress)
        {
            BasketId = basketId;
            ShippingType = shippingType;
            ShippingAddress = shippingAddress;
        }
    }
}

﻿using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.OrderService.Domain
{
    public class Order : BaseIdentifiable
    {
        public Order(Guid id) : base(id)
        {

        }

        public Guid CustomerId { get; private set; }
        public string OrderNo { get; private set; }
        public DateTime DatePlaced { get; private set; }
        public DateTime DatePaid { get; private set; }
        public decimal OrderTotal { get; private set; }
        public decimal TotalVat { get; private set; }
        public int ShippingType { get; private set; }
        public Guid ShippingAddress { get; private set; }
        public int OrderStatus { get; private set; }
        public string Comments { get; private set; }
    }
}

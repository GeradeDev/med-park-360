using System;
using System.Collections.Generic;
using System.Text;

namespace MedPark.Common
{
    public class MedParkEnums
    {
        public enum OrderStatus
        {
            Placed = 1,
            Awaiting_Payment = 2,
            Payment_Received = 3,
            Awaiting_Shipment = 4,
            Shipped = 5,
            Delivered = 6,
            Completed = 7
        }

        public enum OrderShippingType
        {
            Collection = 1,
            Delivery = 2
        }
    }
}

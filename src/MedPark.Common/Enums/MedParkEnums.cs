using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Common.Enums
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

    public enum OrderPaymentType
    {
        Online = 1,
        EFT = 2,
        SnapScan = 3,
        Pay_Pal = 4,
        Venmo = 5,
        EBucks = 6
    }

    public enum PaymentCardType
    {
        Visa = 1,
        MasterCard = 2
    }

    public enum OrderPaymentStatus
    {
        Awaiting_Confirmation = 1,
        Payment_Confirmed = 2,
        Payment_Failed = 3
    }

    public enum CustomerAddressType
    {
        Business = 1,
        Residential = 2
    }
}

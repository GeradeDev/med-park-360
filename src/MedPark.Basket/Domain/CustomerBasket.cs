using MedPark.Common;
using MedPark.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Basket.Domain
{
    public class CustomerBasket : BaseIdentifiable
    {
        public CustomerBasket(Guid id) : base(id)
        {

        }

        public Guid CustomerId { get; private set; }

        public void UpdatedModifiedDate()
            => UpdatedModified();

        public void CreateBasket(Guid customerId)
        {
            if (customerId == Guid.Empty)
                throw new MedParkException("customer_id_invalid", "Custoemr ID for new basket is invalid.");

            CustomerId = customerId;
        }
    }
}

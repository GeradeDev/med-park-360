using MedPark.Common;
using MedPark.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Payment.Domain
{
    public class Customer : BaseIdentifiable
    {
        public Customer(Guid id) : base(id)
        {

        }

        public Guid CustomerId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public void SetCustomer(Guid customerId, string name, string surname)
        {
            CustomerId = customerId;
            FirstName = name;
            LastName = surname;
        }

        public void UpdateDetails(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public override void Use()
        {
            if (CustomerId == Guid.Empty)
                throw new MedParkException("payment_customer_id_invalid", $"The Id for this customer is invalid - {CustomerId}");

            if (string.IsNullOrEmpty(FirstName))
                throw new MedParkException("payment_customer_first_name_invalid", $"The First name for this customer is invalid - {CustomerId}");

            if (string.IsNullOrEmpty(LastName))
                throw new MedParkException("payment_customer_last_name_invalid", $"The Last name for this customer is invalid - {CustomerId}");

            UpdatedModified();
        }
    }
}

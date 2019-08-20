using MedPark.Common;
using MedPark.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.CustomersService.Domain
{
    public class Customer : BaseIdentifiable
    {
        public Customer(Guid id) : base(id)
        {
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime? Birthday { get; private set; }
        public string Email { get; private set; }
        public string Mobile { get; private set; }
        public string Avatar { get; private set; }
        public string AccountType { get; private set; }

        public void Create(string firstname, string lastname, string accounttype)
        {
            FirstName = firstname;
            LastName = lastname;
            AccountType = accounttype;
        }

        public void SetNames(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }
        
        public void SetCustomerAvatar(string avatar)
        {
            Avatar = avatar;
        }

        public void SetCustomerBirthday(DateTime? birthday)
        {
            Birthday = birthday;
        }

        public void SetCustomerMobile(string mobile)
        {
            Mobile = mobile;
        }

        public override void Use()
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(Email))
                throw new MedParkException("customer_invalid","Customer details are invalid");

            UpdatedModified();
        }
    }
}

using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.OrderService.Domain
{
    public class Customer : BaseIdentifiable
    {
        public Customer(Guid id) : base(id)
        {

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Mobile { get; private set; }

        public void Create(string firstname, string lastname = "", string mobile = "", string email = "")
        {
            FirstName = firstname;
            LastName = lastname;
            Mobile = mobile;
            Email = email;
        }
    }
}

using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.CustomersService.Domain
{
    public class Customer : IIdentifiable
    {
        public Guid Id { get; set; }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime? Birthday { get; private set; }
        public string Email { get; private set; }
        public string Mobile { get; private set; }
        public string Avatar { get; private set; }

        public Customer(Guid id, string email)
        {
            Id = id;
            Email = email;
        }

        public void Create(string firstname, string lastname = "", string mobile = "")
        {
            FirstName = firstname;
            LastName = lastname;
            Mobile = mobile;
        }
    }
}

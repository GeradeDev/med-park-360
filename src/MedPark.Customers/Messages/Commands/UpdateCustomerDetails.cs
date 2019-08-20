using MedPark.Common.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.CustomersService.Messages.Commands
{
    public class UpdateCustomerDetails : ICommand
    {
        public Guid Id { get; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Mobile { get; private set; }
        public DateTime? DOB { get; private set; }

        public UpdateCustomerDetails(Guid id, string email, string firstname, string lastname, string mobile, DateTime? dob)
        {
            Id = id;
            Email = email;
            FirstName = firstname;
            LastName = lastname;
            Mobile = mobile;
            DOB = dob;
        }
    }
}

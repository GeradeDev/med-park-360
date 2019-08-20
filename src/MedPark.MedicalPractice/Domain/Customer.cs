using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Domain
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

        public void Create(string firstname, string mobile, string lastname = "", string email = "")
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Mobile = mobile;
        }

        public void UpdateDetails(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public void UpdateMobile(string mobile)
        {
            Mobile = mobile;
        }

        public void UpdateEmail(string email)
        {
            Email = email;
        }

        public override void Use()
        {
            UpdatedModified();
        }
    }
}

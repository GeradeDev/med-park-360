using System;
using Microsoft.AspNetCore.Identity;

namespace MedPark.Web
{
    public class ApplicationUser : IdentityUser
    {
        public Guid IdentityId { get; set; }

        public bool IsAdmin { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public string PassportNo { get; set; }
        public string AccountType { get; set; }

        public ApplicationUser()
        {
            IdentityId = Guid.NewGuid();
        }
    }
}

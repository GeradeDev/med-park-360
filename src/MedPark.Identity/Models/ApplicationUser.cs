using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Identity.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public Guid IdentityId { get; set; }

        public bool IsAdmin { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public string PassportNo { get; set; }

        public ApplicationUser()
        {
            IdentityId = Guid.NewGuid();
        }
    }
}

//new Claim(JwtClaimTypes.Role, "admin"),
//new Claim(JwtClaimTypes.Role, "dataEventRecords.admin"),
//new Claim(JwtClaimTypes.Role, "dataEventRecords.user"),
//new Claim(JwtClaimTypes.Role, "dataEventRecords"),
//new Claim(JwtClaimTypes.Role, "securedFiles.user"),
//new Claim(JwtClaimTypes.Role, "securedFiles.admin"),
//new Claim(JwtClaimTypes.Role, "securedFiles")
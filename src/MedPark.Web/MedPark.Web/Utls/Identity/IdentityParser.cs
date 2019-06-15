using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace MedPark.Web.Utils.Identity
{
    public class IdentityParser : IIdentityParser<ApplicationUser>
    {
        public ApplicationUser Parse(IPrincipal principal)
        {
            // Pattern matching 'is' expression
            // assigns "claims" if "principal" is a "ClaimsPrincipal"
            if (principal is ClaimsPrincipal claims)
            {
                return new ApplicationUser
                {
                    Email = claims.Claims.FirstOrDefault(x => x.Type == "email")?.Value ?? "",
                    Id = claims.Claims.FirstOrDefault(x => x.Type == "sub")?.Value ?? "",
                    LastName = claims.Claims.FirstOrDefault(x => x.Type == "last_name")?.Value ?? "",
                    FirstName = claims.Claims.FirstOrDefault(x => x.Type == "firstname")?.Value ?? "",
                    IdentityId = Guid.Parse(claims.Claims.FirstOrDefault(x => x.Type == "identityid")?.Value ?? ""),
                    AccountType = claims.Claims.FirstOrDefault(x => x.Type == "accounttype")?.Value ?? ""
                };
            }
            throw new ArgumentException(message: "The principal must be a ClaimsPrincipal", paramName: nameof(principal));
        }
    }
}

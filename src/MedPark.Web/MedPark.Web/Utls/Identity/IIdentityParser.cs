using System.Security.Principal;

namespace MedPark.Web.Utils.Identity
{
    public interface IIdentityParser<T>
    {
        T Parse(IPrincipal principal);
    }
}

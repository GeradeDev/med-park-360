using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Web.Models
{
    public class IdentityConfig
    {
        public string ClientId { get; set; }
        public string ClientEndpoint { get; set; }
        public string Authority { get; set; }
        public Boolean RequireHttps { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Identity.Pages
{
    public class BasePageModel : PageModel
    {
        public string ClientName { get; set; }

        public BasePageModel()
        {

        }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var query = context.HttpContext.Request.Query;
            var exists = query.TryGetValue("client_id", out StringValues culture);

            if (!exists)
            {
                exists = query.TryGetValue("returnUrl", out StringValues requesturl);

                if (exists)
                {
                    var request = requesturl.ToArray()[0];
                    Uri uri = new Uri("http://faketopreventexception" + request);
                    var query1 = QueryHelpers.ParseQuery(uri.Query);
                    var client_id = query1.FirstOrDefault(t => t.Key == "client_id").Value;

                    ClientName = client_id.ToString();
                }
            }
            else
            {
                var client_id = query.FirstOrDefault(t => t.Key == "client_id").Value;
                ClientName = GetClientDisplayName(client_id.ToString());
            }
        }




        public string GetClientDisplayName(string clientid)
        {
            switch (clientid)
            {
                case "medpark-web":
                    return "Med-Park 360";
                case "blog":
                    return "Gerade Geldenhuys Personal Website";
                default:
                    return "";
            }
        }
    }
}

using MedPark.Identity.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Identity.Config
{
    public class SeedData
    {
        public static void EnsureSeedData(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = scope.ServiceProvider.GetService<MedParkContext>())
                {
                    EnsureSeedData(context);
                }
            }
        }

        private static void EnsureSeedData(MedParkContext context)
        {
            Console.WriteLine("Seeding database...");

            Console.WriteLine("Clients being populated");

            foreach (var client in IdentityConfig.GetClients())
            {
                if (context.Clients.Where(x => x.ClientId == client.ClientId).FirstOrDefault() == null)
                {
                    var newClient = new ClientEntity { ClientId = client.ClientId, Client = client };
                    newClient.AddDataToEntity();

                    context.Clients.Add(newClient);

                    context.SaveChanges();
                }
                else
                {
                    var newClient = context.Clients.Where(x => x.ClientId == client.ClientId).FirstOrDefault();
                    newClient.Client = client;

                    newClient.AddDataToEntity();

                    context.Clients.Update(newClient);

                    context.SaveChanges();
                }
            }

            if (!context.IdentityResources.Any())
            {
                Console.WriteLine("IdentityResources being populated");
                foreach (var resource in IdentityConfig.GetIdentityResources())
                {
                    var res = new IdentityResourceEntity { IdentityResource = resource };
                    res.AddDataToEntity();

                    context.IdentityResources.Add(res);
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("IdentityResources already populated");
            }

            if (!context.ApiResources.Any())
            {
                Console.WriteLine("ApiResources being populated");
                foreach (var resource in IdentityConfig.GetApiResources())
                {
                    var api = new ApiResourceEntity { ApiResource = resource };
                    api.AddDataToEntity();

                    context.ApiResources.Add(api);
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("ApiResources already populated");
            }

            Console.WriteLine("Done seeding database.");
            Console.WriteLine();
        }
    }
}

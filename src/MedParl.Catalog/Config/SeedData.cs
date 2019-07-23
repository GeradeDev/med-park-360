using MedPark.Catalog.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Catalog
{
    public class SeedData
    {
        public static void EnsureSeedData(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = scope.ServiceProvider.GetService<CatalogDBContext>())
                {
                    EnsureSeedData(context);
                }
            }
        }

        private static void EnsureSeedData(CatalogDBContext context)
        {
            Console.WriteLine("Seeding database...");
            


            Console.WriteLine("Done seeding database.");
            Console.WriteLine();
        }

        private List<Product> GetProducts(List<Product> products)
        {


            return products;
        }

        private List<Category> GetCategories(List<Category> categories)
        {


            return categories;
        }
    }
}

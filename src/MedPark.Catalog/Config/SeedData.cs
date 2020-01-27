using MedPark.Catalog.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

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
            List<FileInfo> files = new DirectoryInfo(Environment.CurrentDirectory + @"/DummyData/").GetFiles().ToList();

            Console.WriteLine("Seeding database...");

            foreach (FileInfo dummyDataFile in files)
            {
                if (dummyDataFile.Name.Contains("Categories"))
                {
                    List<Category> cats = JsonConvert.DeserializeObject<List<Category>>(File.ReadAllText(dummyDataFile.FullName));

                    var currentCats = context.Category.ToList();

                    cats = cats.Where(x => !currentCats.Select(c => c.Id).ToList().Contains(x.Id)).ToList();

                    context.Category.AddRange(cats);
                    context.SaveChanges();
                }

                //Seed Products
                if (dummyDataFile.Name.Contains("Products"))
                {
                    List<Product> prods = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(dummyDataFile.FullName));

                    var currentProds = context.Product.ToList();

                    prods = prods.Where(x => !currentProds.Select(c => c.Id).ToList().Contains(x.Id)).ToList();

                    context.Product.AddRange(prods);
                    context.SaveChanges();
                }

                //Seed Products
                if (dummyDataFile.Name.Contains("Catalog"))
                {
                    List<ProductCatalog> prodCat = JsonConvert.DeserializeObject<List<ProductCatalog>>(File.ReadAllText(dummyDataFile.FullName));

                    var currentProdcats = context.ProductCatalog.ToList();

                    prodCat = prodCat.Where(x => !currentProdcats.Select(c => c.Id).ToList().Contains(x.Id)).ToList();

                    context.ProductCatalog.AddRange(prodCat);
                    context.SaveChanges();
                }
            }

            Console.WriteLine("Done seeding database.");
            Console.WriteLine();
        }
    }
}

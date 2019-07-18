using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings
{
    public class SeedData
    {
        public static void EnsureSeedData(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = scope.ServiceProvider.GetService<MedParkBookingContext>())
                {
                    EnsureSeedData(context);
                }
            }
        }

        private static void EnsureSeedData(MedParkBookingContext context)
        {
            Console.WriteLine("Seeding database...");
            

            Console.WriteLine("Done seeding database.");
            Console.WriteLine();
        }
    }
}

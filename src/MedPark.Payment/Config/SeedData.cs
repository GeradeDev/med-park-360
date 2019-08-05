using MedPark.Common.Enums;
using MedPark.Payment.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Payment
{
    public class SeedData
    {
        public static void EnsureSeedData(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = scope.ServiceProvider.GetService<PaymentDBContext>())
                {
                    EnsureSeedData(context);
                }
            }
        }

        private static void EnsureSeedData(PaymentDBContext context)
        {
            Console.WriteLine("Seeding database...");

            foreach (var item in Enum.GetNames(typeof(OrderPaymentType)))
            {
                if (context.PaymentType.Where(x => x.Name == item.Replace("_", " ")).Count() == 0)
                {
                    PaymentType pt = new PaymentType(Guid.NewGuid());
                    pt.SetPaymentMethod(item.Replace("_", " "));

                    context.PaymentType.Add(pt);
                    context.SaveChanges();
                }
            }

            foreach (var item in Enum.GetNames(typeof(OrderPaymentStatus)))
            {
                if (context.PaymentType.Where(x => x.Name == item.Replace("_", " ")).Count() == 0)
                {
                    PaymentStatus pt = new PaymentStatus(Guid.NewGuid());
                    pt.SetStatus(item.Replace("_", " "));

                    context.PaymentStatus.Add(pt);
                    context.SaveChanges();
                }
            }


            Console.WriteLine("Done seeding database.");
            Console.WriteLine();
        }
    }
}

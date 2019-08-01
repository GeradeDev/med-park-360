using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Payment
{
    public class PaymentDBContext : DbContext
    {
        public PaymentDBContext(DbContextOptions<PaymentDBContext> options) : base(options)
        {

        }
    }
}

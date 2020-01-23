using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MedPark.Common;
using MedPark.Common.RabbitMq;
using MedPark.Payment.Domain;
using MedPark.Payment.Messages.Commands;
using MedPark.Payment.Messages.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MedPark.Payment
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IContainer Container { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PaymentDBContext>(options => options.UseSqlServer(Configuration["Database:ConnectionString"]));
            services.AddMvc(mvc => mvc.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<PaymentDBContext>().As<DbContext>().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly()).AsImplementedInterfaces();
            builder.AddDispatchers();
            builder.AddRabbitMq();
            builder.AddRepository<Customer>();
            builder.AddRepository<CustomerPaymentMethod>();
            builder.AddRepository<PaymentStatus>();
            builder.AddRepository<PaymentStatus>();
            builder.AddRepository<PaymentType>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env, IServiceProvider servProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //SeedData.EnsureSeedData(servProvider);
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRabbitMq()
                .SubscribeCommand<AddPaymentMethod>()
                .SubscribeEvent<CustomerCreated>(@namespace: "customers")
                .SubscribeEvent<OrderPlaced>(@namespace: "order-service")
                .SubscribeEvent<CustomerDetailsUpated>(@namespace: "customers");

            app.UseMvcWithDefaultRoute();
        }
    }
}

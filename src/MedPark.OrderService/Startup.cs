using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using MedPark.Common;
using MedPark.Common.RabbitMq;
using MedPark.OrderService.Domain;
using MedPark.OrderService.Messages.Commands;
using MedPark.OrderService.Messages.Events;
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

namespace MedPark.OrderService
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
            services.AddAutoMapper(typeof(Startup));

            //Add DBContext
            services.AddDbContext<OrderingDbContext>(options => options.UseSqlServer(Configuration["Database:ConnectionString"]));

            services.AddMvc(mvc => mvc.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<OrderingDbContext>().As<DbContext>().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly()).AsImplementedInterfaces();
            builder.AddDispatchers();
            builder.AddRabbitMq();
            builder.AddRepository<Customer>();
            builder.AddRepository<CustomerAddress>();
            builder.AddRepository<Order>();
            builder.AddRepository<LineItem>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRabbitMq()
                .SubscribeCommand<RemoveItemFromOrder>()
                .SubscribeCommand<UpdateOrderItemQuantity>()
                .SubscribeCommand<UpdateOrderPayment>()
                .SubscribeCommand<UpdateOrderShipping>()
                .SubscribeEvent<CustomerCreated>(@namespace: "customers")
                .SubscribeEvent<AddressCreated>(@namespace: "customers")
                .SubscribeEvent<BasketCheckedOut>(@namespace: "basket-service")
                .SubscribeEvent<CustomerDetailsUpated>(@namespace: "customers");

            app.UseMvcWithDefaultRoute();
        }
    }
}

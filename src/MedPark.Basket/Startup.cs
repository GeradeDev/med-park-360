using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MedPark.Basket.Domain;
using MedPark.Basket.Messaging.Commands;
using MedPark.Common;
using MedPark.Common.RabbitMq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using MedPark.Basket.Messaging.Events;
using Microsoft.Extensions.Hosting;
using MedPark.Common.Redis;

namespace MedPark.Basket
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IContainer Container { get; private set; }

        public Startup(IWebHostEnvironment env)
        {
            Configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.{env.EnvironmentName}.json", true).AddEnvironmentVariables().Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            services.AddRedis(Configuration);

            //Add DBContext
            services.AddDbContext<BasketDBContext>(options => options.UseSqlServer(Configuration["Database:ConnectionString"]));

            services.AddMvc(mvc => mvc.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<BasketDBContext>().As<DbContext>().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly()).AsImplementedInterfaces();
            builder.AddDispatchers();
            builder.AddRabbitMq();
            builder.AddRepository<CustomerBasket>();
            builder.AddRepository<BasketItem>();
            builder.AddRepository<Product>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
                .SubscribeCommand<CreateBasket>()
                .SubscribeCommand<AddProductToBasket>()
                .SubscribeCommand<CheckoutBasket>()
                .SubscribeEvent<CustomerCreated>(@namespace: "customers");

            app.UseMvcWithDefaultRoute();
        }
    }
}

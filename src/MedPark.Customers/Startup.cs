using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.Messages;
using MedPark.Common.RabbitMq;
using MedPark.CustomersService.Domain;
using MedPark.CustomersService.Dto;
using MedPark.CustomersService.Handlers.Customers;
using MedPark.CustomersService.Messages.Commands;
using MedPark.CustomersService.Messages.Events;
using MedPark.CustomersService.Queries;
using MedPark.CustomersService.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RawRabbit.Configuration;

namespace MedPark.CustomersService
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
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //Auto Mapper
            services.AddAutoMapper();

            //Add DBContext
            services.AddDbContext<CustomersDbContext>(options => options.UseSqlServer(Configuration["Database:ConnectionString"]));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            services.AddScoped(typeof(IQueryHandler<GetCustomer, CustomerDto>), typeof(GetCustomerHandler));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.AddDispatchers();
            builder.AddRabbitMq();

            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            app.UseStaticFiles();

            app.UseRabbitMq()
                .SubscribeEvent<SignedUp>(@namespace: "identity")
                .SubscribeEvent<AddressCreated>(@namespace: "gateway");

            app.UseMvcWithDefaultRoute();
        }
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.Messages;
using MedPark.Common.RabbitMq;
using MedPark.CustomersService.Domain;
using MedPark.CustomersService.Dto;
using MedPark.CustomersService.Handlers.Customers;
using MedPark.CustomersService.Messages.Commands;
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

namespace MedPark.CustomersService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Auto Mapper
            services.AddAutoMapper();

            services.AddRabbitMq();

            //Add DBContext
            services.AddDbContext<CustomersDbContext>(options => options.UseSqlServer(Configuration["Database:ConnectionString"]));

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped(typeof(ICommandHandler<CreateCustomer>), typeof(CreateCustomerHandler));

            services.AddDispatchers();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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

            app.UseRabbitMq();

            app.UseMvcWithDefaultRoute();
        }
    }
    
}

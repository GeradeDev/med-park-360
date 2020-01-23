using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
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
using Autofac.Extensions.DependencyInjection;
using MedPark.Common;
using MedPark.Common.RabbitMq;
using MedPark.Bookings.Domain;
using MedPark.Bookings.Messages.Events;
using MedPark.Common.Handlers;
using MedPark.Bookings.Queries;
using MedPark.Bookings.Handlers.Bookings;
using MedPark.Bookings.Dto;
using MedPark.Bookings.Messaging.Command;
using MedPark.Bookings.Services;
using MedPark.Common.RestEase;
using System.Reflection;
using Microsoft.Extensions.Hosting;

namespace MedPark.Bookings
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
            services.AddDbContext<MedParkBookingContext>(options => options.UseSqlServer(Configuration["Database:ConnectionString"]));

            services.AddMvc(mvc => mvc.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<MedParkBookingContext>().As<DbContext>().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly()).AsImplementedInterfaces();
            builder.AddDispatchers();
            builder.AddRabbitMq();
            builder.AddRepository<Customer>();
            builder.AddRepository<Specialist>();
            builder.AddRepository<Appointment>();
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
                .SubscribeCommand<AddAppointment>()
                .SubscribeEvent<SpecialistSignedUp>(@namespace: "identity")
                .SubscribeEvent<CustomerCreated>(@namespace: "customers")
                .SubscribeEvent<CustomerDetailsUpated>(@namespace: "customers")
                .SubscribeEvent<SpecialistDetailsUpdated>(@namespace: "medical-practice");

            app.UseMvcWithDefaultRoute();
        }
    }
}

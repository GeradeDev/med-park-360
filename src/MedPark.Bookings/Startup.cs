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
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();

            //Add DBContext
            services.AddDbContext<MedParkBookingContext>(options => options.UseSqlServer(Configuration["Database:ConnectionString"]));

            services.AddScoped(typeof(IQueryHandler<AppointmentQuery, SpecialistAppointmentsDto>), typeof(SpecialistAppointmentsQueryHandler));
            services.AddScoped(typeof(IQueryHandler<AppointmentQuery, CustomerAppointmentsDto>), typeof(CustomerAppointmentsQueryHandler));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            SeedData.EnsureSeedData(services.BuildServiceProvider());

            var builder = new ContainerBuilder();

            builder.RegisterType<MedParkBookingContext>().As<DbContext>().InstancePerLifetimeScope();

            builder.Populate(services);
            builder.AddDispatchers();
            builder.AddRabbitMq();
            builder.AddRepository<Customer>();
            builder.AddRepository<Specialist>();
            builder.AddRepository<Appointment>();


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

            app.UseRabbitMq()
                .SubscribeCommand<AddAppointment>()
                .SubscribeEvent<SpecialistSignedUp>("identity")
                .SubscribeEvent<CustomerCreated>("customers");

            app.UseMvcWithDefaultRoute();
        }
    }
}

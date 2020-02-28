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
using MedPark.Common.RabbitMq;
using MedPark.CustomersService.Messages.Events;
using MedPark.MedicalPractice.Config;
using MedPark.MedicalPractice.Domain;
using MedPark.MedicalPractice.Dto;
using MedPark.MedicalPractice.Handlers;
using MedPark.MedicalPractice.Handlers.MedicalPractice;
using MedPark.MedicalPractice.Messages.Commands;
using MedPark.MedicalPractice.Messages.Events;
using MedPark.MedicalPractice.Queries;
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

namespace MedPark.MedicalPractice
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
            services.AddDbContext<MedicalPracticeDbContext>(options => options.UseSqlServer(Configuration["Database:ConnectionString"]));
            services.AddMvc(mvc => mvc.EnableEndpointRouting = false).AddNewtonsoftJson().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<MedicalPracticeDbContext>().As<DbContext>().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly()).AsImplementedInterfaces();
            builder.AddDispatchers();
            builder.AddRabbitMq();
            builder.AddRepository<Specialist>();
            builder.AddRepository<PendingRegistration>();
            builder.AddRepository<Practice>();
            builder.AddRepository<Address>();
            builder.AddRepository<OperatingHours>();
            builder.AddRepository<Institute>();
            builder.AddRepository<MedicalScheme>();
            builder.AddRepository<AcceptedMedicalScheme>();
            builder.AddRepository<Qualifications>();
            builder.AddRepository<Speciality>();
            builder.AddRepository<Customer>();
            builder.AddRepository<AppointmentType>();
            builder.AddRepository<AppointmentAccepted>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //SeedData.EnsureSeedData(serviceProvider);
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRabbitMq()
                .SubscribeCommand<AddPracticeAcceptedMedicalScheme>()
                .SubscribeCommand<UpdatePracticeAcceptedMedicalScheme>()
                .SubscribeCommand<RemoveAcceptedMedicalScheme>()
                .SubscribeCommand<AddInstitute>()
                .SubscribeCommand<AddAddress>()
                .SubscribeCommand<UpdateAddress>()
                .SubscribeCommand<AddMedicalScheme>()
                .SubscribeCommand<AddOperatingHours>()
                .SubscribeCommand<UpdateOperatingHours>()
                .SubscribeCommand<AddPendingRegistration>()
                .SubscribeCommand<UpdatePendingRegistration>()
                .SubscribeCommand<AddQualification>()
                .SubscribeCommand<RemoveQualification>()
                .SubscribeCommand<UpdateSpecialistDetails>()
                .SubscribeCommand<LinkSpecialistAppointmentType>()
                .SubscribeEvent<SpecialistSignedUp>(@namespace: "identity")
                .SubscribeEvent<CustomerCreated>(@namespace: "customers")
                .SubscribeEvent<CustomerDetailsUpated>(@namespace: "customers");

            app.UseMvcWithDefaultRoute();
        }
    }
}

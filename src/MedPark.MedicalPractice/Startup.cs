using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.MedicalPractice.Config;
using MedPark.MedicalPractice.Domain;
using MedPark.MedicalPractice.Dto;
using MedPark.MedicalPractice.Handlers.MedicalPractice;
using MedPark.MedicalPractice.Messages.Events;
using MedPark.MedicalPractice.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();

            //Add DBContext
            services.AddDbContext<MedicalPracticeDbContext>(options => options.UseSqlServer(Configuration["Database:ConnectionString"]));

            services.AddScoped(typeof(IQueryHandler<GetSpecialist, SpecialistDto>), typeof(GetSpecialistHandler));
            services.AddScoped(typeof(IQueryHandler<GetRegistrationOTP, PendingRegistrationDto>), typeof(GetRegistrationOTPHandler));
            services.AddScoped(typeof(IQueryHandler<PracticeQuery, PracticeDto>), typeof(PracticeQueryHandler));
            services.AddScoped(typeof(IQueryHandler<PracticeQuery, PracticeDetailDTO>), typeof(PracticeDetailQueryHandler));
            services.AddScoped(typeof(IQueryHandler<InstituteQuery, InstituteDTO>), typeof(InstituteQueryHandler));
            services.AddScoped(typeof(IQueryHandler<MedicalSchemeQuery, MedicalSchemeDTO>), typeof(MedicalSchemeQueryHandler));
            services.AddScoped(typeof(IQueryHandler<OperatingHoursQuery, OperatingHoursDTO>), typeof(OperatingHoursQueryHandler));
            services.AddScoped(typeof(IQueryHandler<SpecialistQualificationsQuery, SpecialistQualificationDTO>), typeof(SpecialistQualificationsQueryHandler));


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            SeedData.EnsureSeedData(services.BuildServiceProvider());

            var builder = new ContainerBuilder();

            builder.RegisterType<MedicalPracticeDbContext>().As<DbContext>().InstancePerLifetimeScope();

            builder.Populate(services);
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
                .SubscribeEvent<SpecialistSignedUp>(@namespace: "identity");

            app.UseMvcWithDefaultRoute();
        }
    }
}

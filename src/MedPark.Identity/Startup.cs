using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Stores;
using MedPark.Identity.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MedPark.Identity.Models;
using Microsoft.AspNetCore.Identity;
using IdentityServer4.Services;
using MedPark.Identity.Config;
using System.Reflection;
using MedPark.Common.RabbitMq;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MedPark.Common.RestEase;
using MedPark.Identity.Services;
using Microsoft.Extensions.Hosting;

namespace MedPark.Identity
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
            services.AddMvc(mvc => mvc.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddHttpClient();

            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<ApplicationUserContext>(options => options.UseSqlServer(Configuration["MedPark360IdentityStore:ConnectionString"]));
            services.AddDbContext<MedParkContext>(options => options.UseSqlServer(Configuration["MedPark360IdentityStore:ConnectionString"]));

            services.AddTransient<IProfileService, DefaultProfileService>();
            services.AddTransient<IClientStore, ClientStore>();
            services.AddTransient<IResourceStore, ResourceStore>();

            services.AddDefaultEndpoint<IMedicalPracticeService>("med-practice-service");

            services.AddAuthentication();

            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationUserContext>();

            services.AddIdentityServer()
            .AddResourceStore<ResourceStore>()
            .AddClientStore<ClientStore>()
            .AddAspNetIdentity<ApplicationUser>()
            .AddProfileService<DefaultProfileService>()
            .AddOperationalStore(options =>
             {
                 options.ConfigureDbContext = b => b.UseSqlServer(Configuration["MedPark360IdentityStore:ConnectionString"]);

                 // this enables automatic token cleanup. this is optional.
                 //options.EnableTokenCleanup = true;
                 //options.TokenCleanupInterval = 30; // interval in seconds
             })
             .AddDeveloperSigningCredential(true);


            //SeedData.EnsureSeedData(services.BuildServiceProvider());
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.AddRabbitMq();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRabbitMq();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseIdentityServer();

            app.UseMvcWithDefaultRoute();
        }
    }
}

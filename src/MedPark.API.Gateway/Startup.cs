using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MedPark.API.Gateway.Controllers;
using MedPark.API.Gateway.Services;
using MedPark.Common.RabbitMq;
using MedPark.Common.Redis;
using MedPark.Common.RestEase;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MedPark.API.Gateway
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IContainer Container { get; private set; }
        IHostEnvironment _env;

        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            Configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.{env.EnvironmentName}.json", true).AddEnvironmentVariables().Build();
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomAPIVersioning()
                    .AddCustomCors()
                    .AddRestEaseServices();

            services.AddRedis(Configuration);

            services.AddMvc(mvc => mvc.EnableEndpointRouting = false).AddNewtonsoftJson().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
    ;
            services.AddOptions();
            services.Configure<RestEaseOptions>(Configuration.GetSection("restEase"));
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly()).AsImplementedInterfaces();
            builder.AddServiceBus(_env);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRabbitMq();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }



    static class CustomExtensionsMethods
    {
        private static readonly string[] Headers = new[] { "X-Operation", "X-Resource", "X-Total-Count" };

        public static IServiceCollection AddRestEaseServices(this IServiceCollection services)
        {
            services.AddDefaultEndpoint<ICustomerService>("customer-service");
            services.AddDefaultEndpoint<IMedicalPracticeService>("med-practice-service");
            services.AddDefaultEndpoint<IBookingService>("booking-service");
            services.AddDefaultEndpoint<ICatalogService>("catalog-service");
            services.AddDefaultEndpoint<IBasketService>("basket-service");
            services.AddDefaultEndpoint<IOrderService>("order-service");
            services.AddDefaultEndpoint<IPaymentService>("payment-service");

            return services;
        }

        public static IServiceCollection AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", cors =>
                        cors.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .WithExposedHeaders(Headers));
            });

            return services;
        }

        public static IServiceCollection AddCustomAPIVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;

                //Add Conventions
                options.Conventions.Controller<CustomersController>().HasApiVersion(new ApiVersion(1, 0));
                options.Conventions.Controller<AuthenticationController>().HasApiVersion(new ApiVersion(1, 0));
                options.Conventions.Controller<MedicalPracticeController>().HasApiVersion(new ApiVersion(1, 0));
                options.Conventions.Controller<BookingsController>().HasApiVersion(new ApiVersion(1, 0));
                options.Conventions.Controller<BasketController>().HasApiVersion(new ApiVersion(1, 0));
                options.Conventions.Controller<CatalogController>().HasApiVersion(new ApiVersion(1, 0));
                options.Conventions.Controller<OrderController>().HasApiVersion(new ApiVersion(1, 0));
                options.Conventions.Controller<PaymentController>().HasApiVersion(new ApiVersion(1, 0));
            });

            return services;
        }

        public static void AddServiceBus(this ContainerBuilder builder, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //Use RabbitMq for messaging in development
                builder.AddRabbitMq();
            }
            else
            {
                //Use RabbitMq for messaging in development
                builder.AddRabbitMq();
            }
        }


    }
}

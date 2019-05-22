using DShop.Common.Messages;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Common;
using RawRabbit.Configuration;
using RawRabbit.Enrichers.MessageContext;
using RawRabbit.Instantiation;
using RawRabbit.Pipe;
using RawRabbit.Pipe.Middleware;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MedPark.Common.RabbitMq
{
    public static class Extension
    {
        public static IBusSubscriber UseRabbitMq(this IApplicationBuilder app)
        => new BusSubscriber(app);

        public static void AddRabbitMq(this IServiceCollection services)
        {
            services.AddSingleton(context =>
            {
                var configuration = context.GetService<IConfiguration>();
                var options = configuration.GetValue<RabbitMqOptions>("rabbitMq");

                return options;
            });

            services.AddSingleton(context =>
            {
                var configuration = context.GetService<IConfiguration>();
                var options = configuration.GetValue<RawRabbitConfiguration>("rabbitMq");

                return options;
            });

            var assembly = Assembly.GetCallingAssembly();

            services.Scan(scan => scan
                .FromAssemblies(assembly)
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            ConfigureBus(services);
        }

        private static void ConfigureBus(IServiceCollection services)
        {
            services.AddScoped<IInstanceFactory>(context =>
            {
                var options = context.GetService<RabbitMqOptions>();
                var configuration = context.GetService<RawRabbitConfiguration>();
                var namingConventions = new CustomNamingConventions(options.Namespace);
                //var tracer = context.Resolve<ITracer>();

                return RawRabbitFactory.CreateInstanceFactory(new RawRabbitOptions
                {
                    DependencyInjection = ioc =>
                    {
                        ioc.AddSingleton(options);
                        ioc.AddSingleton(configuration);
                        ioc.AddSingleton<INamingConventions>(namingConventions);
                        //ioc.AddSingleton(tracer);
                    },
                    Plugins = p => p
                        .UseAttributeRouting()
                        .UseRetryLater()
                        .UpdateRetryInfo()
                        .UseMessageContext<CorrelationContext>()
                        .UseContextForwarding()
                        //.UseJaeger(tracer)
                });
            });

            services.AddScoped(context => context.GetService<IInstanceFactory>().Create());
        }

        private class CustomNamingConventions : NamingConventions
        {
            public CustomNamingConventions(string defaultNamespace)
            {
                ExchangeNamingConvention = type => GetNamespace(type, defaultNamespace).ToLowerInvariant();
                RoutingKeyConvention = type =>
                    $"#.{GetRoutingKeyNamespace(type, defaultNamespace)}{type.Name.Underscore()}".ToLowerInvariant();
                ErrorExchangeNamingConvention = () => $"{defaultNamespace}.error";
                RetryLaterExchangeConvention = span => $"{defaultNamespace}.retry";
                RetryLaterQueueNameConvetion = (exchange, span) =>
                    $"{defaultNamespace}.retry_for_{exchange.Replace(".", "_")}_in_{span.TotalMilliseconds}_ms".ToLowerInvariant();
            }

            private static string GetRoutingKeyNamespace(Type type, string defaultNamespace)
            {
                var @namespace = type.GetCustomAttribute<MessageNamespaceAttribute>()?.Namespace ?? defaultNamespace;

                return string.IsNullOrWhiteSpace(@namespace) ? string.Empty : $"{@namespace}.";
            }

            private static string GetNamespace(Type type, string defaultNamespace)
            {
                var @namespace = type.GetCustomAttribute<MessageNamespaceAttribute>()?.Namespace ?? defaultNamespace;

                return string.IsNullOrWhiteSpace(@namespace) ? "#" : $"{@namespace}";
            }
        }

        private class RetryStagedMiddleware : StagedMiddleware
        {
            public override string StageMarker { get; } = RawRabbit.Pipe.StageMarker.MessageDeserialized;

            public override async Task InvokeAsync(IPipeContext context,
                CancellationToken token = new CancellationToken())
            {
                var retry = context.GetRetryInformation();
                if (context.GetMessageContext() is CorrelationContext message)
                {
                    message.Retries = retry.NumberOfRetries;
                }

                await Next.InvokeAsync(context, token);
            }
        }

        private static IClientBuilder UpdateRetryInfo(this IClientBuilder clientBuilder)
        {
            clientBuilder.Register(c => c.Use<RetryStagedMiddleware>());

            return clientBuilder;
        }
    }
}

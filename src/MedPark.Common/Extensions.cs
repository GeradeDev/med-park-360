using MedPark.Common.Dispatchers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedPark.Common
{
    public static class Extensions
    {
        public static void AddDispatchers(this IServiceCollection services)
        {
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<IDispatcher, Dispatcher>();
        }

        public static string Underscore(this string value)
           => string.Concat(value.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString()));

        //public static TModel GetOptions<TModel>(this IConfiguration configuration, string section) where TModel : new()
        //{
        //    var model = new TModel();
        //    configuration.GetSection(section).Bind(model);

        //    return model;
        //}
    }
}

using Autofac;
using MedPark.Common.Dispatchers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace MedPark.Common
{
    public static class Extensions
    {
        private static string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
        private static string numbers = "1234567890";

        public static void AddDispatchers(this ContainerBuilder builder)
        {
            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
            builder.RegisterType<Dispatcher>().As<IDispatcher>();
            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>();
        }

        public static string Underscore(this string value)
           => string.Concat(value.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString()));

        public static TModel GetOptions<TModel>(this IConfiguration configuration, string section) where TModel : new()
        {
            var model = new TModel();
            configuration.GetSection(section).Bind(model);

            return model;
        }

        public static string CalculateMD5Hash(this string email)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(email);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static string GetAvatar(this string email)
        {
            return Globals.GravatarEndpoint + email.ToLower().CalculateMD5Hash();
        }

        public static void AddRepository<TEntity>(this ContainerBuilder builder) where TEntity : class, IIdentifiable
           => builder.Register(ctx => new MedParkRepository<TEntity>(ctx.Resolve<DbContext>()))
               .As<IMedParkRepository<TEntity>>()
               .InstancePerLifetimeScope();


        public static T Bind<T>(this T model, Expression<Func<T, object>> expression, object value)
            => model.Bind<T, object>(expression, value);

        public static T BindId<T>(this T model, Expression<Func<T, Guid>> expression)
            => model.Bind<T, Guid>(expression, Guid.NewGuid());

        private static TModel Bind<TModel, TProperty>(this TModel model, Expression<Func<TModel, TProperty>> expression,
            object value)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                memberExpression = ((UnaryExpression)expression.Body).Operand as MemberExpression;
            }

            var propertyName = memberExpression.Member.Name.ToLowerInvariant();
            var modelType = model.GetType();
            var field = modelType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .SingleOrDefault(x => x.Name.ToLowerInvariant().StartsWith($"<{propertyName}>"));
            if (field == null)
            {
                return model;
            }

            field.SetValue(model, value);

            return model;
        }

        public static string NewOTP(this string otp, int length)
        {
            //Generate OTP with alpha and numeric characters
            string characters = alphabets + small_alphabets + numbers;

            for (int i = 0; i <= length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);

                    character = characters.ToCharArray()[index].ToString();

                } while (otp.IndexOf(character) != -1);

                otp += character;
            }

            return otp;
        }

        public static string GetInitials(this string fullName)
        {
            return String.Join("", fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        public static string GenerateOrderNo(this string orderNo, int orderCount)
        {
            return "MPO" + orderCount.ToString().PadLeft(7, '0');
        }

        public static List<DayOfWeek> GetWeekDays(this DateTime date)
        {
            List<DayOfWeek> days = new List<DayOfWeek>(){
                                DayOfWeek.Sunday,
                                DayOfWeek.Monday,
                                DayOfWeek.Tuesday,
                                DayOfWeek.Wednesday,
                                DayOfWeek.Thursday,
                                DayOfWeek.Friday,
                                DayOfWeek.Saturday };

            return days;
        }
    }
}

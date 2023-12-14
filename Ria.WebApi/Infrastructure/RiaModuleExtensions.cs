using System.Reflection;

using MediatR;

using Ria.Business.Features.ATM.Commands;
using Ria.Data.Customers;

namespace Ria.Api.Infrastructure
{
    public static class RiaModuleExtensions
    {
        public static IServiceCollection AddRiaModules(
            this IServiceCollection services)

        {
            services.AddMediatR(new[] { typeof(CreatePayoutCommand).GetTypeInfo().Assembly, typeof(Program).GetTypeInfo().Assembly });
            services.AddSingleton<ICustomerRepository, CustomerRepository>();


            services.AddHttpClient("Customers", c =>
            {
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            return services;
        }
    }
}

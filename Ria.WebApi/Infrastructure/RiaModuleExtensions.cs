using System.Reflection;

using MediatR;

using Ria.Business.Features.ATM.Commands;

namespace Ria.Api.Infrastructure
{
    public static class RiaModuleExtensions
    {
        public static IServiceCollection AddRiaModules(
            this IServiceCollection services)

        {
            services.AddMediatR(new[] { typeof(CreatePayoutCommand).GetTypeInfo().Assembly, typeof(Program).GetTypeInfo().Assembly });
            return services;
        }
    }
}

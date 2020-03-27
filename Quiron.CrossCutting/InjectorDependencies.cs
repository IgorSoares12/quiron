using Microsoft.Extensions.DependencyInjection;
using Quiron.Data.Context;

namespace Quiron.CrossCutting
{
    public static class InjectorDependencies
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.RegisterRepository();
            services.RegisterService();
            services.AddScoped<QuironContext>();
        }
    }
}
using Core.Querys;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddQueries();
        }
    }
}

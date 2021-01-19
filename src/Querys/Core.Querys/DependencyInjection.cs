using Core.Querys.Exemple;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Querys
{
    public static class DependencyInjection
    {
        public static void AddQueries(this IServiceCollection services)
        {
            services.AddTransient<IExempleSqlQueryContext, ExempleSqlQueryContext>();
        }
    }
}

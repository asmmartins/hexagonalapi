using AutoMapper;
using Core.Repositories.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Repositories
{
    public static class DependencyInjection
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddProfiles();
        }

        private static void AddProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(TerminalProfile));
        }
    }
}

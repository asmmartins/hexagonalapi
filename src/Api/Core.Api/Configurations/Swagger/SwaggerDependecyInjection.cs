using Microsoft.Extensions.DependencyInjection;

namespace Core.Api.Configurations.Swagger
{
    internal static class SwaggerDependecyInjection
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();
        }
    }
}

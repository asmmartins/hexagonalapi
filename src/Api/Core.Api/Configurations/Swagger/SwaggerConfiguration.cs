using Microsoft.AspNetCore.Builder;

namespace Core.Api.Configurations.Swagger
{
    internal static class SwaggerConfiguration
    {
        public static void UseSwaggerUserInterface(this IApplicationBuilder app)
        {            
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core API v1");
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Circa.User.IoC
{
    public static class OpenApiServices
    {
        public static IServiceCollection AddOpenApi(this IServiceCollection services)
        {
            services.AddOpenApiDocument(settings =>
            {
                settings.DocumentName = "circa-users-webapi";
                settings.Title = "Circa Users WebApi";
                settings.Version = "1";
                settings.Description = "Circa.Users.WebApi is the default service to deal with user stuff." +
                                       "Like profile, metrics, authorization.";
            });
            return services;
        }

        public static IApplicationBuilder UseOpenApiDocuments(this IApplicationBuilder app)
        {
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseReDoc();
            return app;
        }
    }
}

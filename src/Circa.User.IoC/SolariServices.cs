using Circa.User.Domain;
using Circa.Users.Domain.UserProfile;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solari.Callisto.DependencyInjection;
using Solari.Callisto.Tracer;
using Solari.Deimos;
using Solari.Oberon;
using Solari.Sol;
using Solari.User.Infra;
using Solari.Vanth.DependencyInjection;

namespace Circa.User.IoC
{
    public static class SolariServices
    {
        public static IServiceCollection AddSolariServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSol(configuration)
                    .AddVanth()
                    .AddOberon()
                    .AddCallistoWithDefaults(ServiceLifetime.Scoped,
                                             cfg => cfg.RegisterScopedCollection<
                                                 IUserProfileRepository, UserProfileRepository, UserProfileDocument
                                             >(Collections.UserProfile))
                    .AddDeimos(plugins => plugins.AddCallistoTracing());
            return services;
        }

        public static IApplicationBuilder UseSolari(this IApplicationBuilder app)
        {
            app.UseSol();
            return app;
        }
    }


}

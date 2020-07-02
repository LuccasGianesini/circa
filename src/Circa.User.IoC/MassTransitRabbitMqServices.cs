using Circa.Shared.Domain;
using MassTransit;
using MassTransit.RabbitMqTransport;
using MassTransit.RabbitMqTransport.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solari.Callisto.Integrations.MassTransit;

namespace Circa.User.IoC
{
    public static class MassTransitRabbitMqServices
    {
        public static IServiceCollection AddMassTransitRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(cfg =>
            {
                cfg.SetKebabCaseEndpointNameFormatter();
                cfg.UsingRabbitMq((context, configurator) => ConfigureBus(context, configurator, configuration));


            });
            services.AddMassTransitHostedService();
            return services;
        }

        private static void ConfigureBus(IBusRegistrationContext ctx, IRabbitMqBusFactoryConfigurator configurator,
                                         IConfiguration configuration)
        {
            configurator.CallistoMessageDataRepository(configuration);
            configurator.ConfigureEndpoints(ctx);
        }
    }
}

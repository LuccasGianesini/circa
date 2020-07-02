using System;
using Circa.Shared.Domain;
using Circa.User.Components;
using Circa.User.Components.UserProfile;
using Circa.User.Contracts;
using Circa.User.Contracts.UserProfile.Commands;
using GreenPipes;
using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using MassTransit.MultiBus;
using Microsoft.Extensions.DependencyInjection;

namespace Circa.User.IoC
{
    public static class MassTransitMediatorServices
    {
        public static IServiceCollection AddMassTransitMediator(this IServiceCollection services)
        {

            services.AddMediator(cfg =>
            {
                cfg.SetKebabCaseEndpointNameFormatter();
                cfg.ConfigureUserProfileStack();

            });
            return services;
        }

        private static void ConfigureUserProfileStack(this IServiceCollectionMediatorConfigurator cfg)
        {
            cfg.AddConsumer<CreateUserProfileConsumer>();
            cfg.AddRequestClient<ICreateUserProfile>();
        }

    }
}

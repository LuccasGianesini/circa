using System;
using AutoMapper;
using Circa.User.Components.UserProfile;
using Circa.User.Domain;
using Circa.User.Domain.UserProfile;
using Circa.Users.Domain.UserProfile;
using Circa.Users.Domain.UserProfile.Mappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solari.Callisto.DependencyInjection;
using Solari.Callisto.Tracer;
using Solari.Deimos;
using Solari.Sol;
using Solari.User.Infra;
using Solari.Vanth.DependencyInjection;

namespace Circa.User.IoC
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserProfileDatabaseOperations, UserProfileDatabaseOperations>();

            return services;
        }

        public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserProfileMappingProfile));
            return services;
        }
    }
}

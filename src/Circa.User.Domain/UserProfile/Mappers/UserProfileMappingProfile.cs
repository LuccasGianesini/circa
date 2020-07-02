using System;
using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using Circa.User.Domain.UserProfile.Inputs;

namespace Circa.Users.Domain.UserProfile.Mappers
{
    public class UserProfileMappingProfile : Profile
    {
        public UserProfileMappingProfile()
        {
            CreateUserProfileInputToUserProfile();
        }

        private void CreateUserProfileInputToUserProfile()
        {
            CreateMap<CreateUserProfileInput, UserProfileDocument>()
                .ForMember(prop => prop.CreatedAt, o => o.MapFrom(f => DateTimeOffset.UtcNow))
                .ForMember(prop => prop.UpdatedAt, o => o.MapFrom(f => DateTimeOffset.UtcNow))
                .ForAllOtherMembers(a =>
                {
                    if (((PropertyInfo) a.DestinationMember).PropertyType == typeof(IEnumerable<UserResources>))
                    {
                        a.MapFrom(f => new List<UserResources>());
                    }
                });
        }
    }
}

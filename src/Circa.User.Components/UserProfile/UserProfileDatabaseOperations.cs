using AutoMapper;
using Circa.Shared.Domain;
using Circa.User.Domain;
using Circa.User.Domain.UserProfile;
using Circa.User.Domain.UserProfile.Inputs;
using Circa.Users.Domain.UserProfile;
using Solari.Callisto.Abstractions.CQR;
using Solari.Callisto.Framework;

namespace Circa.User.Components.UserProfile
{
    public class UserProfileDatabaseOperations : IUserProfileDatabaseOperations
    {
        private readonly ICallistoInsertOperationFactory _insertFactory;
        private readonly IMapper _mapper;


        public UserProfileDatabaseOperations(ICallistoInsertOperationFactory insertFactory, IMapper mapper)
        {
            _insertFactory = insertFactory;
            _mapper = mapper;
        }

        public ICallistoInsertOne<UserProfileDocument> CreateInsertProfileOperation(CreateUserProfileInput input)
        {
            try
            {
                UserProfileDocument userProfileDocument = _mapper.Map<CreateUserProfileInput, UserProfileDocument>(input);
                if (userProfileDocument is null)
                {
                    throw UserExceptionHelper.CreateUserException("Got a null resulting document after mapping from input. Halting Operation.");
                }
                return _insertFactory.CreateInsertOne(userProfileDocument);
            }
            catch (AutoMapperMappingException am)
            {
                throw UserExceptionHelper.CreateUserException("Unable to map user profile input to user profile.", am);
            }
        }

    }
}

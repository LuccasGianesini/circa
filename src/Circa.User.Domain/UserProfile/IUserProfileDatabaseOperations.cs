using Circa.User.Domain.UserProfile.Inputs;
using Circa.Users.Domain.UserProfile;
using Solari.Callisto.Abstractions.CQR;

namespace Circa.User.Domain.UserProfile
{
    public interface IUserProfileDatabaseOperations
    {
        ICallistoInsertOne<UserProfileDocument> CreateInsertProfileOperation(CreateUserProfileInput input);
    }
}

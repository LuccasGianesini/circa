using Circa.User.Domain.UserProfile.Inputs;

namespace Circa.User.Contracts.UserProfile.Commands
{
    public interface ICreateUserProfile
    {
        CreateUserProfileInput ProfileInput { get; set; }
    }
}

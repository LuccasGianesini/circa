using System;

namespace Circa.Shared.Contracts.UserProfile.Events
{
    public interface IUserProfileCreated
    {
        Guid UserId { get; }
        string Nickname { get; }

    }
}

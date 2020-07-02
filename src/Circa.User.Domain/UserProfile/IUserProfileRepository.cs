using Circa.Shared.Domain;
using Solari.Sol.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Solari.Callisto.Abstractions.CQR;
using Solari.Vanth;

namespace Circa.Users.Domain.UserProfile
{
    public interface IUserProfileRepository
    {
        /// <summary>
        /// Create a user profile. The profile can only be created (inserted) if there is not a profile with the same Nickname-Email key.
        /// </summary>
        /// <param name="profile">The user profile to be inserted</param>
        /// <returns>Guid with the id of the document</returns>
        ValueTask<Result<CircaDatabaseResult>> CreateUserProfile(ICallistoInsertOne<UserProfileDocument> profile);
    }
}

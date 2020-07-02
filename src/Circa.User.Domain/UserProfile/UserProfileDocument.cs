using System;
using System.Collections.Generic;
using Solari.Callisto.Abstractions;

namespace Circa.Users.Domain.UserProfile
{
    public class UserProfileDocument : IDocumentRoot
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// The id of the user in the keycloak database.
        /// </summary>
        public string KeycloakId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        /// <summary>
        /// Campaigns that the user is the owner of (DM).
        /// </summary>
        public IEnumerable<UserResources> OwnedCampaigns { get; set; }

        /// <summary>
        /// Campaigns the user is playing or played.
        /// </summary>
        public IEnumerable<UserResources> PlayedCampaigns { get; set; }

        /// <summary>
        /// Campaigns the user is allowed to DM.
        /// </summary>
        public IEnumerable<UserResources> AllowedCampaigns { get; set; }

        /// <summary>
        /// User characters.
        /// </summary>
        public IEnumerable<UserResources> Characters { get; set; }

        /// <summary>
        /// User monsters.
        /// </summary>
        public IEnumerable<UserResources> Monsters { get; set; }




    }
}

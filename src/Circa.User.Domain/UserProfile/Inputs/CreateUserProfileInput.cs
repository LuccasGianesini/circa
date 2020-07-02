namespace Circa.User.Domain.UserProfile.Inputs
{
    public class CreateUserProfileInput
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string KeycloakId { get; set; }
    }
}

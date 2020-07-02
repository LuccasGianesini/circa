namespace Circa.Shared.Domain
{
    /// <summary>
    ///  Queues names.
    /// Must follow service:event_that_happened
    /// </summary>
    public static class CircaRabbitMqEndpoints
    {
        public static class User
        {
            public const string UserProfileCreatedQueue = "user:user_profile_created";

        }
    }
}

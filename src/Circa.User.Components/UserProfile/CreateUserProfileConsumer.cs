using System;
using System.Linq;
using System.Threading.Tasks;
using Circa.Shared.Contracts.UserProfile.Events;
using Circa.Shared.Domain;
using Circa.User.Contracts;
using Circa.User.Contracts.UserProfile.Commands;
using Circa.User.Domain.UserProfile;
using Circa.Users.Domain.UserProfile;
using MassTransit;
using MassTransit.RabbitMqTransport.Integration;
using Microsoft.Extensions.Logging;
using Solari.Callisto.Abstractions.CQR;
using Solari.Titan;
using Solari.Titan.Abstractions;
using Solari.Vanth;

namespace Circa.User.Components.UserProfile
{
    public class CreateUserProfileConsumer : IConsumer<ICreateUserProfile>
    {
        private readonly IUserProfileRepository _repository;
        private readonly IUserProfileDatabaseOperations _operations;
        private readonly ILogger<CreateUserProfileConsumer> _logger;
        private readonly IPublishEndpoint _publisher;

        public CreateUserProfileConsumer(IUserProfileRepository repository,
                                         IUserProfileDatabaseOperations operations,
                                         ILogger<CreateUserProfileConsumer> logger,
                                         IPublishEndpoint publisher)
        {
            _repository = repository;
            _operations = operations;
            _logger = logger;
            _publisher = publisher;
        }

        public async Task Consume(ConsumeContext<ICreateUserProfile> context)
        {
            ILoggingScope scope = LoggingScope.OpenScope();
            _logger.LogInformation($"Creating the user profile for user");
            scope.Push("Keycloak_ID", context.Message.ProfileInput.KeycloakId);

            ICallistoInsertOne<UserProfileDocument> operation = _operations.CreateInsertProfileOperation(context.Message.ProfileInput);

            Result<CircaDatabaseResult> databaseResult = await _repository.CreateUserProfile(operation);
            if (databaseResult.HasErrors)
            {
                // Throw exception;
            }

            Guid userId = databaseResult.Data.Ids.Value.First();
            scope.Push("Mongo_User_ID", userId);

            // // Publish event to all other services consuming the queue:user:profile-created.
            // await _publisher.Publish<IUserProfileCreated>(new
            // {
            //     UserId = userId,
            //     context.Message.ProfileInput.Nickname
            // });
            await context.Publish<IUserProfileCreated>(new
            {
                UserId = userId,
                context.Message.ProfileInput.Nickname
            });

            scope.CloseScope();

            // Respond to the Request client at UserProfileController.
            await context.RespondAsync<IUserProfileCreated>(new
            {
                UserId = userId,
                context.Message.ProfileInput.Nickname
            });
        }
    }
}

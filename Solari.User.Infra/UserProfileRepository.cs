using System;
using System.Threading.Tasks;
using Circa.Shared.Domain;
using Circa.Users.Domain.UserProfile;
using MongoDB.Driver;
using Solari.Callisto;
using Solari.Callisto.Abstractions.CQR;
using Solari.Sol.Utils;
using Solari.Vanth;
using Solari.Vanth.Builders;

namespace Solari.User.Infra
{
    public class UserProfileRepository : CallistoRepository<UserProfileDocument>,IUserProfileRepository
    {
        private readonly IResultFactory _resultFactory;

        public UserProfileRepository(ICallistoCollectionContext<UserProfileDocument> context, IResultFactory resultFactory) : base(context)
        {
            _resultFactory = resultFactory;
        }

        public async ValueTask<Result<CircaDatabaseResult>> CreateUserProfile(ICallistoInsertOne<UserProfileDocument>  profile)
        {
            try
            {
                UserProfileDocument inserted = await Insert.One(profile);
                return _resultFactory.Success(CircaDatabaseResult.ForOne(inserted.Id));
            }
            catch (MongoException e)
            {
                return _resultFactory.ExceptionError<CircaDatabaseResult>(e);
            }
        }


    }
}

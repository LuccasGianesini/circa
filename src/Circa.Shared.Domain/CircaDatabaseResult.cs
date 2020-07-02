using Solari.Sol.Utils;
using System;
using System.Collections.Generic;
using Solari.Vanth;

namespace Circa.Shared.Domain
{
    public class CircaDatabaseResult
    {
        public Maybe<IEnumerable<Guid>> Ids { get; }
        public long UpdatedCount { get; }
        public long MatchedCount { get; }

        private CircaDatabaseResult(IEnumerable<Guid> ids, long updatedCount, long matchedCount)
        {
            Ids = ids is null ? Maybe<IEnumerable<Guid>>.None : Maybe<IEnumerable<Guid>>.Some(ids);
            UpdatedCount = updatedCount;
            MatchedCount = matchedCount;
        }

        public static CircaDatabaseResult ForOne(Guid id)
        {
            return ForOne(id, 1, 1);
        }
        public static CircaDatabaseResult ForOne(Guid id, long updatedCount, long matchedCount)
        {
            return new CircaDatabaseResult(new[] {id}, updatedCount, matchedCount);
        }


        public static CircaDatabaseResult ForMany(IEnumerable<Guid> ids, long updatedCount, long matchedCount)
        {
            return new CircaDatabaseResult(ids, updatedCount, matchedCount);
        }
    }
}

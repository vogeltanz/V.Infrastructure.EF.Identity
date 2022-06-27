using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using V.Domain.Base.Entities.Abstraction;
using V.Infrastructure.EF.Base;
using V.Infrastructure.EF.Identity.Base.Entities;

namespace V.Infrastructure.EF.Identity.Base
{
    public class RepositoryIdentityUR<T, TKey, TIdentityKey> : Repository<T, TKey> where T : class, IEntity<TKey> where TIdentityKey : IEquatable<TIdentityKey>
    {
        protected IdentityDbContext<User<TIdentityKey>, Role<TIdentityKey>, TIdentityKey> dbContext;

        public RepositoryIdentityUR(IdentityDbContext<User<TIdentityKey>, Role<TIdentityKey>, TIdentityKey> dbContext) : base(dbContext.Set<T>())
        {
            this.dbContext = dbContext;
        }
    }
}

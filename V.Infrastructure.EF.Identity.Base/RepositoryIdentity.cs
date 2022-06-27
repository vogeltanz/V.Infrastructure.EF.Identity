using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using V.Domain.Base.Entities.Abstraction;
using V.Infrastructure.EF.Identity.Base.Entities;

namespace V.Infrastructure.EF.Identity.Base
{
    public class RepositoryIdentity<T, TKey, TIdentityKey> : Repository<T, TKey> where T : class, IEntity<TKey> where TIdentityKey : IEquatable<TIdentityKey>
    {
        protected IdentityDbContext<IdentityUser<TIdentityKey>, IdentityRole<TIdentityKey>, TIdentityKey> dbContext;

        public RepositoryIdentity(IdentityDbContext<IdentityUser<TIdentityKey>, IdentityRole<TIdentityKey>, TIdentityKey> dbContext) : base(dbContext.Set<T>())
        {
            this.dbContext = dbContext;
        }
    }
}

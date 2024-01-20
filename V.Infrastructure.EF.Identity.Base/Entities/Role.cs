using Microsoft.AspNetCore.Identity;
using V.Domain.Base.Entities.Abstraction;
using V.Domain.Identity.Entities.Abstraction;

namespace V.Infrastructure.EF.Identity.Base.Entities
{
    public class Role<TKey> : IdentityRole<TKey>, IRole<TKey>, IEntity<TKey>, IEntityCreated, IEntityModified where TKey : IEquatable<TKey>
    {
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public Role() : base()
        {
        }

        public Role(string name) : base(name)
        {
            //Id = Guid.NewGuid().ToString();
        }

        public Role(string name, TKey id) : base(name)
        {
            Id = id;
            NormalizedName = name.ToUpper();
        }

    }
}

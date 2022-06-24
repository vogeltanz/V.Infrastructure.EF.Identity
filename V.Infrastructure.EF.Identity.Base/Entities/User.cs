using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Domain.Base.Entities.Abstraction;
using V.Domain.Identity.Entities.Abstraction;

namespace V.Infrastructure.EF.Identity.Base.Entities
{
    public class User<TKey> : IdentityUser<TKey>, IUser<TKey>, IUserLockout, IEntity<TKey>, IEntityDateTime where TKey : IEquatable<TKey>
    {
        public virtual string? FirstName { get; set; }
        public virtual string? LastName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public User() : base()
        {
        }

        public User(string username) : base(username)
        {
            //Id = Guid.NewGuid().ToString();
        }
    }
}

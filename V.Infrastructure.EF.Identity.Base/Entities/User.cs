using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Domain.Identity.Entities.Abstraction;

namespace V.Infrastructure.EF.Identity.Base.Entities
{
    public class User : IdentityUser<string>, IUser<string>, IUserLockout
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
            Id = Guid.NewGuid().ToString();
        }
    }
}

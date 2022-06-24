using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using V.Domain.Base.Entities.Abstraction;
using V.Domain.Base.Repository;
using V.Infrastructure.EF.Identity.Base.Entities;

namespace V.Infrastructure.EF.Identity.Base
{
    public class Repository<T, TKey, TIdentityKey> : IRepository<T, TKey> where T : class, IEntity<TKey> where TIdentityKey : IEquatable<TIdentityKey>
    {
        protected IdentityDbContext<User<TIdentityKey>, Role<TIdentityKey>, TIdentityKey> dbContext;
        internal DbSet<T> dbSet;
        public Repository(IdentityDbContext<User<TIdentityKey>, Role<TIdentityKey>, TIdentityKey> dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            dbSet.Update(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet;
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public virtual T GetById(TKey id)
        {
            return dbSet.FirstOrDefault(entity => entity.Id.Equals(id));
        }
    }
}

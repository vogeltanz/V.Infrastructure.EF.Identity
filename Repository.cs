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
using V.Infrastructure.EF.Base.Identity.Entities;

namespace V.Infrastructure.EF.Base
{
    public class Repository<T, TKey> : IRepository<T, TKey> where T : class, IEntity<TKey>
    {
        protected IdentityDbContext<User, Role, string> dbContext;
        internal DbSet<T> dbSet;
        public Repository(IdentityDbContext<User, Role, string> dbContext)
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

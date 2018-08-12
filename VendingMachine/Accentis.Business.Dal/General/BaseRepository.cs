using Accentis.Business.Interface.Repository;
using Accentis.Database.Domain;
using Accentis.Database.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Accentis.Business.Dal.General
{
    public abstract class BaseRepository<T> : IBaseRepository<T>, IDisposable
        where T : BaseEntity
    {
        protected readonly ApplicationDbContext context;

        public BaseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void DeleteAll(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Delete(entity);
            }
        }

        public void DeleteBy(Expression<Func<T, bool>> predicate)
        {
            var enumerable = context.Set<T>().Where(predicate);
            context.Set<T>().RemoveRange(enumerable);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            var query = context.Set<T>().Where(predicate);
            return query;
        }

        public T Get(int id)
        {
            return context.Set<T>().Find(id);
        }

        public T Get(Guid id)
        {
            return context.Set<T>().Find(id); throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public Microsoft.AspNet.Identity.UserManager<ApplicationUser> GetUserManager()
        {
            throw new NotImplementedException();
        }

        public T Insert(T entity)
        {
            return context.Set<T>().Add(entity);
        }

        public IEnumerable<T> InsertRange(IEnumerable<T> entities)
        {
            return context.Set<T>().AddRange(entities);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}

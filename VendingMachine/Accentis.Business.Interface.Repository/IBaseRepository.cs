using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNet.Identity;
using Accentis.Database.Domain;
using Accentis.Database.Domain.Models;

namespace Accentis.Business.Interface.Repository
{
    public interface IBaseRepository<T> where T: BaseEntity
    {
        IQueryable<T> GetAll();

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        T Get(int id);

        T Get(Guid id);

        T Insert(T entity);

        IEnumerable<T> InsertRange(IEnumerable<T> entities);

        void Delete(T entity);

        void DeleteAll(IEnumerable<T> entities);

        void Update(T entity);

        void Save();

        UserManager<ApplicationUser> GetUserManager();

        void DeleteBy(Expression<Func<T, bool>> predicate);
    }
}

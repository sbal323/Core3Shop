using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core3Shop.Dal.Data.Repository.Contracts
{
    public interface IRepository<T> where T:class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>,IOrderedQueryable<T>> orderBy = null, List<string> includeProperties = null);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Remove(int id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
    }
}

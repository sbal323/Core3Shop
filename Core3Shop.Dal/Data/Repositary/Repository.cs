using Core3Shop.Dal.Data.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core3Shop.Dal.Data.Repositary
{
    public class Repository<T> : IRepository<T> where T: class
    {
        protected readonly DbContext _dbContext;
        internal DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbSet.AsNoTracking().Where(predicate);
            return query.ToList();
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, IEnumerable<Expression<Func<T, object>>> includeProperties = null)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();
            query = query.Where(predicate);
            if (includeProperties != null)
            {
                query = Include(includeProperties);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public T Get(int id)
        {
            return _dbSet.Find(id);
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }
        public IEnumerable<T> GetAllWithInclude(IEnumerable<Expression<Func<T, object>>> includeProperties)
        {
            return Include(includeProperties).ToList();
        }
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void Remove(int id)
        {
            _dbSet.Remove(Get(id));
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
        public void UpdateRange(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }
        private IQueryable<T> Include(IEnumerable<Expression<Func<T, object>>> includeProperties)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}

using Core3Shop.Dal.Data.Repositary.Contracts;
using Core3Shop.Dal.Data.Repository.Contracts;
using Core3Shop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core3Shop.Dal.Data.Repositary
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Categories = new CategoryRepository(_dbContext);
            Frequencies = new Repository<Frequency>(_dbContext);
            Services = new Repository<Service>(_dbContext);
            Repositories = new Dictionary<Type, object>
            {
                { typeof(Repository<Frequency>), Frequencies },
                { typeof(Repository<Service>), Services },
                { typeof(Repository<Category>), Categories }
            };
        }
        public ICategoryRepository Categories { get; private set; }
        public IRepository<Frequency> Frequencies { get; private set; }
        public IRepository<Service> Services { get; private set; }
        public Dictionary<Type, object> Repositories { get; private set; }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public IRepository<T> GetDictionaryRepositary<T>() where T : DictionaryBase
        {
            if (Repositories.ContainsKey(typeof(Repository<T>)))
            {
                return (IRepository<T>)Repositories[typeof(Repository<T>)];
            }
            return null;
        }

    }
}

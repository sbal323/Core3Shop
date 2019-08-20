using Core3Shop.Dal.Data.Repositary.Contracts;
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
            Frequencies = new FrequencyRepository(_dbContext);
        }
        public ICategoryRepository Categories {get; private set;}
        public IFrequencyRepository Frequencies { get; private set; }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}

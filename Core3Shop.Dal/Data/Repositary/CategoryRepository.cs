using Core3Shop.Dal.Data.Repositary.Contracts;
using Core3Shop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Core3Shop.Dal.Data.Repositary
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _dbContext;
        public CategoryRepository(ApplicationDbContext context): base(context)
        {
            _dbContext = context;
        }
        public IEnumerable<Category> GetTopCategories(int top)
        {
            return _dbContext.Categories.Take(top);
        }
    }
}

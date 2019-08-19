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
            //return dbSet.Take(top);
        }

        public void Update(Category category)
        {
            //var dbCategory = Get(category.Id);
            //dbCategory.Name = category.Name;
            //dbCategory.DisplayOrder = category.DisplayOrder;
            if (category.Id != 0)
            {
                dbSet.Update(category);
            }
            else
            {
                dbSet.Add(category);
            }
            dbContext.SaveChanges();
        }
    }
}

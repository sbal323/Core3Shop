using Core3Shop.Dal.Data.Repository.Contracts;
using Core3Shop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core3Shop.Dal.Data.Repositary.Contracts
{
    public interface ICategoryRepository: IRepository<Category>
    {
        IEnumerable<Category> GetTopCategories(int top);
        void Update(Category category);
    }
}

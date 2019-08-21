using Core3Shop.Bl.Contracts;
using Core3Shop.Dal.Data.Repositary.Contracts;
using Core3Shop.Models;
using System.Collections.Generic;

namespace Core3Shop.Bl
{
    public class BlCategory : IBlCategory
    {
        private IUnitOfWork _unitOfWork;
        private ICategoryRepository _repository;
        public BlCategory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.Categories;
        }
        public void Save(Category category)
        {
            if (category.Id == 0)
            {
                _unitOfWork.Categories.Add(category);
            }
            else
            {
                _unitOfWork.Categories.Update(category);
            }
            _unitOfWork.Save();
        }
        public Category Get(int id)
        {
            return _unitOfWork.Categories.Get(id);
        }
        public void Delete(int id)
        {
            _unitOfWork.Categories.Remove(id);
            _unitOfWork.Save();
        }
        public IEnumerable<Category> GetAll()
        {
            return _unitOfWork.Categories.GetAll();
        }
    }
}

using Core3Shop.Bl.Contracts;
using Core3Shop.Dal.Data;
using Core3Shop.Dal.Data.Repositary.Contracts;
using Core3Shop.Dal.Data.Repository.Contracts;
using Core3Shop.Models;
using System.Collections.Generic;

namespace Core3Shop.Bl
{
    public class BlDictionary<T>:IBlDictionary<T> where T: DictionaryBase
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<T> _repository;
        public BlDictionary(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _repository = unitOfWork.GetDictionaryRepositary<T>();
        }
        public void Save(T entity)
        {
            if (entity.Id == 0)
            {
                _repository.Add(entity);
            }
            else
            {
                _repository.Update(entity);
            }
            _unitOfWork.Save();
        }
        public T Get(int id)
        {
            return _repository.Get(id);
        }
        public void Delete(int id)
        {
            _repository.Remove(id);
            _unitOfWork.Save();
        }
        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }
    }
}

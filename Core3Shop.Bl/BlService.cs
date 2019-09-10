using Core3Shop.Bl.Contracts;
using Core3Shop.Bl.Models;
using Core3Shop.Dal.Data.Repositary.Contracts;
using Core3Shop.Dal.Data.Repository.Contracts;
using Core3Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core3Shop.Bl
{
    public class BlService : IBlService
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<Service> _repository;
        private List<Expression<Func<Service, object>>>  _includeProperties = new List<Expression<Func<Service, object>>>
            {
                x => x.Category,
                x => x.Frequency
            };
        public BlService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.Services;
        }
        public IEnumerable<ServiceBlModel> GetAll()
        {
           
            return _unitOfWork.Services
                .GetAllWithInclude(_includeProperties)
                .Select(x=> new ServiceBlModel() {
                  ServiceModel  = x
                });
        }
        public IEnumerable<ServiceBlModel> Get(IEnumerable<int> itemIds)
        {

            return _unitOfWork.Services
                .GetAllWithInclude(_includeProperties)
                .Where(x=> itemIds.Any(y=> y == x.Id))
                .Select(x => new ServiceBlModel()
                {
                    ServiceModel = x
                });
        }
        public ServiceBlModel Get(int id)
        {
            return new ServiceBlModel()
            {
                ServiceModel = _unitOfWork.Services.Find(x => x.Id == id, includeProperties: _includeProperties).First()
            };
        }

        public void Delete(int id)
        {
            _repository.Remove(id);
            _unitOfWork.Save();
        }
        public void Save(ServiceBlModel entity)
        {
            if (entity.ServiceModel.Id == 0)
            {
                _repository.Add(entity.ServiceModel);
            }
            else
            {
                _repository.Update(entity.ServiceModel);
            }
            _unitOfWork.Save();
        }
    }
}

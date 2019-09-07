using Core3Shop.Bl.Contracts;
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
    public class BlService : BlDictionary<Service>, IBlService
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<Service> _repository;
        private List<Expression<Func<Service, object>>>  _includeProperties = new List<Expression<Func<Service, object>>>
            {
                x => x.Category,
                x => x.Frequency
            };
        public BlService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.Services;
        }
        public new IEnumerable<Service> GetAll()
        {
           
            return _unitOfWork.Services.GetAllWithInclude(_includeProperties);
        }
        public new Service Get(int id)
        {
            var includeProperties = new List<Expression<Func<Service, object>>>
            {
                x => x.Category,
                x => x.Frequency
            };
            return _unitOfWork.Services.Find(x=> x.Id == id, includeProperties: _includeProperties).First();
        }
    }
}

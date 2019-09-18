using Core3Shop.Bl.Contracts;
using Core3Shop.Bl.Models;
using Core3Shop.Dal.Data.Repositary.Contracts;
using Core3Shop.Dal.Data.Repository.Contracts;
using Core3Shop.Models;
using Core3Shop.Utility.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core3Shop.Bl
{
    public class BlOrder : IBlOrder
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<Order> _repository;
        public BlOrder(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.Orders;
        }
        public void ChangeStatus(int id, string status)
        {
            var order = _repository.Get(id);
            order.Status = status;
            _unitOfWork.Save();
        }

        public IEnumerable<Order> GetAll()
        {
            return _repository.GetAll();
        }
        public IEnumerable<Order> GetPending()
        {
            return _repository.Find(x=> x.Status == OrderStatuses.Submitted);
        }
        public IEnumerable<Order> GetApproved()
        {
            return _repository.Find(x => x.Status == OrderStatuses.Approved);
        }
        public void Save(Order entity)
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

        public Order Get(int id)
        {
            List<Expression<Func<Order, object>>> includeProperties = new List<Expression<Func<Order, object>>>
            {
                x => x.Items
            };
            return _repository.Find(x => x.Id == id, includeProperties: includeProperties).First();
        }
    }
}

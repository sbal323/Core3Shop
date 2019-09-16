using Core3Shop.Bl.Contracts;
using Core3Shop.Dal.Data.Repositary.Contracts;
using Core3Shop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core3Shop.Bl
{
    public class BlUser : IBlUser
    {
        private IUnitOfWork _unitOfWork;
        private IUserRepository _repository;
        public BlUser(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.Users;
        }
        public IEnumerable<ApplicationUser> GetAll(string currentUserId)
        {
            return _repository.Find(x=> x.Id!=currentUserId);
        }

        public void Lock(string id)
        {
            _repository.LockUser(id);
        }

        public void Unlock(string id)
        {
            _repository.UnlockUser(id);
        }
    }
}

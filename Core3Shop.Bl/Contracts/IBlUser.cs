using Core3Shop.Bl.Models;
using Core3Shop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core3Shop.Bl.Contracts
{
    public interface IBlUser
    {
        void Lock(string id);
        void Unlock(string id);
        IEnumerable<ApplicationUser> GetAll(string currentUserId);
    }
}

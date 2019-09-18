using Core3Shop.Bl.Models;
using Core3Shop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core3Shop.Bl.Contracts
{
    public interface IBlOrder
    {
        IEnumerable<Order> GetAll();
        void ChangeStatus(int id, string status);
        void Save(Order entity);
        IEnumerable<Order> GetPending();
        IEnumerable<Order> GetApproved();
        Order Get(int id);

    }
}

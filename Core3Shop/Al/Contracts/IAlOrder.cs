using Core3Shop.Models;
using Core3Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3Shop.Al.Contracts
{
    public interface IAlOrder
    {
        IEnumerable<Order> GetAllOrders();
        IEnumerable<Order> GetPendingOrders();
        IEnumerable<Order> GetApprovedOrders();
        OrderDetailsViewModel GetDetailsModel(int id);
        void Approve(int id);
        void Reject(int id);
    }
}

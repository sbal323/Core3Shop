using Core3Shop.Al.Contracts;
using Core3Shop.Bl.Contracts;
using Core3Shop.Bl.Models;
using Core3Shop.Models;
using Core3Shop.Models.ViewModels;
using Core3Shop.Utility.Consts;
using Core3Shop.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core3Shop.Al
{
    public class AlOrder : IAlOrder
    {
        private readonly IBlOrder _blOrder;

        public AlOrder(IBlOrder blOrder)
        {
            _blOrder = blOrder;
        }
        
        public IEnumerable<Order> GetAllOrders()
        {
            return _blOrder.GetAll();
        }

        public IEnumerable<Order> GetPendingOrders()
        {
            return _blOrder.GetPending();
        }

        public IEnumerable<Order> GetApprovedOrders()
        {
            return _blOrder.GetApproved();
        }

        public OrderDetailsViewModel GetDetailsModel(int id)
        {
            var order = _blOrder.Get(id);
            return new OrderDetailsViewModel()
            {
                Order = order,
                TotalPrice = order.Items.Sum(x=>x.Price)
            };
        }
        public void Approve(int id)
        {
            _blOrder.ChangeStatus(id, OrderStatuses.Approved);
        }
        public void Reject(int id)
        {
            _blOrder.ChangeStatus(id, OrderStatuses.Rejected);
        }
    }
}

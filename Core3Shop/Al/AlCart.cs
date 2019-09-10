using Core3Shop.Al.Contracts;
using Core3Shop.Bl.Contracts;
using Core3Shop.Managers;
using Core3Shop.Models;
using Core3Shop.Utility.Consts;
using Core3Shop.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3Shop.Al
{
    public class AlCart : IAlCart
    {
        private readonly IBlService _blService;
        private readonly IBlDictionary<Order> _blOrder;
        private IHttpContextAccessor _httpContextAccessor;
        public AlCart(IBlService blService, IHttpContextAccessor httpContextAccessor, IBlDictionary<Order> blOrder)
        {
            _blService = blService;
            _blOrder = blOrder;
            _httpContextAccessor = httpContextAccessor;
        }
        public CartViewModel GetCart()
        {
            
            var session = new SessionManager(_httpContextAccessor.HttpContext);
            var cartItems = session.GetCart();
                var services = _blService.Get(cartItems);
            return new CartViewModel
            {
                SelectedServices = services.ToList(),
                TotalPrice = services.Sum(x => x.TotalPrice)
            };
        }

        public PlaceOrderViewModel GetPlaceOrderModel(Order order)
        {
            var session = new SessionManager(_httpContextAccessor.HttpContext);
            var cartItems = session.GetCart();
            var services = _blService.Get(cartItems);
            return new PlaceOrderViewModel
            {
                SelectedServices = services.ToList(),
                TotalPrice = services.Sum(x => x.TotalPrice),
                Order = order
            };
        }

        public void RemoveFromCart(int serviceId)
        {
            var session = new SessionManager(_httpContextAccessor.HttpContext);
            session.DeleteFromCart(serviceId);
        }

        public void SaveOrder(Order order)
        {
            var session = new SessionManager(_httpContextAccessor.HttpContext);
            var cartItems = session.GetCart();
            var services = _blService.Get(cartItems);
            order.Status = OrderStatuses.Submitted;
            order.OrderDate = DateTime.Now;
            order.ItemsCount = cartItems.Count;
            order.Items = new List<OrderItem>();
            foreach (var item in services)
            {
                order.Items.Add(new OrderItem()
                {
                    Price = item.TotalPrice,
                    ServiceId = item.ServiceModel.Id,
                    ServiceName = item.ServiceModel.Name
                });
            }
            _blOrder.Save(order);
            session.EmptyCart();
        }
    }
}

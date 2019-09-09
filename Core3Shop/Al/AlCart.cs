using Core3Shop.Al.Contracts;
using Core3Shop.Bl.Contracts;
using Core3Shop.Managers;
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
        private IHttpContextAccessor _httpContextAccessor;
        public AlCart(IBlService blService, IHttpContextAccessor httpContextAccessor)
        {
            _blService = blService;
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

        public void RemoveFromCart(int serviceId)
        {
            var session = new SessionManager(_httpContextAccessor.HttpContext);
            session.DeleteFromCart(serviceId);
        }
    }
}

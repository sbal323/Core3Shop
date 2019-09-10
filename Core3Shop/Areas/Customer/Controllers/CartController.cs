using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core3Shop.Al.Contracts;
using Core3Shop.Models;
using Core3Shop.Utility.Consts;
using Core3Shop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Core3Shop.Areas.Customer.Controllers
{
    [Area(AreaNames.Customer)]
    public class CartController : Controller
    {
        private readonly IAlCart _alCart;
        public CartController(IAlCart alCart)
        {
            _alCart = alCart;
        }
        public IActionResult Index()
        {
            var model = _alCart.GetCart();
            return View(model);
        }
        public IActionResult Remove(int serviceId)
        {
            _alCart.RemoveFromCart(serviceId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult PlaceOrder()
        {
            var model = _alCart.GetPlaceOrderModel(new Order());
            return View(model);
        }
        [HttpPost]
        public IActionResult PlaceOrder(PlaceOrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errorModel = _alCart.GetPlaceOrderModel(model.Order);
                return View(errorModel);
            }
            _alCart.SaveOrder(model.Order);
            return RedirectToAction(nameof(OrderConfirmation), "Cart", new { id = model.Order.Id});
        }
        public IActionResult OrderConfirmation(int id)
        {
            return View(id);
        }
    }
}
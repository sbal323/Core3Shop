using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core3Shop.Al.Contracts;
using Core3Shop.Utility.Consts;
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
    }
}
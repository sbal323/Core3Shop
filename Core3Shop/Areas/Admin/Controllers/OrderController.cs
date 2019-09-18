using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core3Shop.Al.Contracts;
using Core3Shop.Bl.Contracts;
using Core3Shop.Utility.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core3Shop.Areas.Admin.Controllers
{
    [Authorize]
    [Area(AreaNames.Admin)]
    public class OrderController : Controller
    {
        private readonly IAlOrder _alOrder;

        public OrderController(IAlOrder alOrder)
        {
            _alOrder = alOrder;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            return Json(new { data = _alOrder.GetAllOrders() });
        }
        public IActionResult GetAllApproved()
        {
            return Json(new { data = _alOrder.GetApprovedOrders() });
        }
        public IActionResult GetAllPending()
        {
            return Json(new { data = _alOrder.GetPendingOrders() });
        }
        public IActionResult Details(int id)
        {
            var model = _alOrder.GetDetailsModel(id);
            return View(model);
        }
        public IActionResult Approve(int id)
        {
            _alOrder.Approve(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Reject(int id)
        {
            _alOrder.Reject(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
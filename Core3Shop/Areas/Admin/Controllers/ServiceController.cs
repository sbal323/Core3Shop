using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core3Shop.Dal.Data.Repositary.Contracts;
using Microsoft.AspNetCore.Mvc;
using Core3Shop.Utility.Consts;
using Core3Shop.Models;
using Core3Shop.Bl.Contracts;
using Microsoft.AspNetCore.Hosting;

namespace Core3Shop.Areas.Admin.Controllers
{
    [Area(AreaNames.Admin)]
    public class ServiceController : Controller
    {
        private readonly IBlDictionary<Service> _blService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ServiceController(IBlDictionary<Service> blService, IWebHostEnvironment webHostEnvironment)
        {
            _blService = blService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            var service = new Service();
            if (id != null)
            {
                service = _blService.Get(id.Value);
                if (service == null)
                {
                    return NotFound();
                }
            }
            return View(service);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Service service)
        {
            if (ModelState.IsValid)
            {
                _blService.Save(service);
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = (_blService as Bl.BlService).GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var service = _blService.Get(id);
            if(service == null)
            {
                return Json(new { success = false, message = "Service does not exists" });
            }
            _blService.Delete(id);

            return Json(new { success = true, message = "Service deleted successfully", service });
        }
    }
}
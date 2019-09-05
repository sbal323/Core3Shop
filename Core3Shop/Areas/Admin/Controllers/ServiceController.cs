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
using Core3Shop.Models.ViewModels;
using Core3Shop.Al.Contracts;
using System.IO;

namespace Core3Shop.Areas.Admin.Controllers
{
    [Area(AreaNames.Admin)]
    public class ServiceController : Controller
    {
        private readonly IAlService _alService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ServiceController(IAlService alService, IWebHostEnvironment webHostEnvironment)
        {
            _alService = alService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            var model = _alService.GetServiceModel(id);
            if (id != null && model.Service == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ServiceViewModel serviceModel)
        {
            if (ModelState.IsValid)
            {
                _alService.ProcessServiceFiles(_webHostEnvironment.WebRootPath, HttpContext.Request.Form.Files, serviceModel.Service);
                _alService.BlService.Save(serviceModel.Service);
                return RedirectToAction(nameof(Index));
            }
            var model = _alService.GetServiceModel(serviceModel.Service);
            return View(model);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _alService.BlService.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var service = _alService.BlService.Get(id);
            if(service == null)
            {
                return Json(new { success = false, message = "Service does not exists" });
            }
            _alService.BlService.Delete(id);

            return Json(new { success = true, message = "Service deleted successfully", service });
        }
    }
}
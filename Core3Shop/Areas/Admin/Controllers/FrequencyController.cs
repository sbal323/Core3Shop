using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core3Shop.Dal.Data.Repositary.Contracts;
using Microsoft.AspNetCore.Mvc;
using Core3Shop.Utility.Consts;
using Core3Shop.Models;
using Core3Shop.Bl.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace Core3Shop.Areas.Admin.Controllers
{
    [Authorize]
    [Area(AreaNames.Admin)]
    public class FrequencyController : Controller
    {
        private readonly IBlDictionary<Frequency> _blFrequency;
        public FrequencyController(IBlDictionary<Frequency> blFrequency)
        {
            _blFrequency = blFrequency;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            var frequency = new Frequency();
            if (id != null)
            {
                frequency = _blFrequency.Get(id.Value);
                if (frequency == null)
                {
                    return NotFound();
                }
            }
            return View(frequency);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Frequency frequency)
        {
            if (ModelState.IsValid)
            {
                _blFrequency.Save(frequency);
                return RedirectToAction(nameof(Index));
            }
            return View(frequency);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _blFrequency.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var frequency = _blFrequency.Get(id);
            if(frequency == null)
            {
                return Json(new { success = false, message = "Frequency does not exists" });
            }
            _blFrequency.Delete(id);

            return Json(new { success = true, message = "Frequency deleted successfully", frequency });
        }
    }
}
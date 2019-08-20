using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core3Shop.Dal.Data.Repositary.Contracts;
using Microsoft.AspNetCore.Mvc;
using Core3Shop.Utility.Consts;
using Core3Shop.Models;

namespace Core3Shop.Areas.Admin.Controllers
{
    [Area(AreaNames.Admin)]
    public class FrequencyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public FrequencyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
                frequency = _unitOfWork.Frequencies.Get(id.Value);
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

                if (frequency.Id == 0)
                {
                    _unitOfWork.Frequencies.Add(frequency);
                }
                else
                {
                    _unitOfWork.Frequencies.Update(frequency);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(frequency);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Frequencies.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var frequency = _unitOfWork.Frequencies.Get(id);
            if(frequency == null)
            {
                return Json(new { success = false, message = "Frequency does not exists" });
            }
            _unitOfWork.Frequencies.Remove(frequency);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Frequency deleted successfully", frequency });
        }
    }
}
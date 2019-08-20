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
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            var category = new Category();
            if (id != null)
            {
                category = _unitOfWork.Categories.Get(id.Value);
                if (category == null)
                {
                    return NotFound();
                }
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (ModelState.IsValid)
            {

                if (category.Id == 0)
                {
                    _unitOfWork.Categories.Add(category);
                }
                else
                {
                    _unitOfWork.Categories.Update(category);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Categories.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var category = _unitOfWork.Categories.Get(id);
            if(category == null)
            {
                return Json(new { success = false, message = "Category does not exists" });
            }
            _unitOfWork.Categories.Remove(category);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Category deleted successfully", category });
        }
    }
}
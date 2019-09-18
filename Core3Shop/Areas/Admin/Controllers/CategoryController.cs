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
    public class CategoryController : Controller
    {
        private readonly IBlDictionary<Category> _blCategory;
        public CategoryController(IBlDictionary<Category> blCategory)
        {
            _blCategory = blCategory;
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
                category = _blCategory.Get(id.Value);
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
                _blCategory.Save(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _blCategory.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var category = _blCategory.Get(id);
            if(category == null)
            {
                return Json(new { success = false, message = "Category does not exists" });
            }
            _blCategory.Delete(id);

            return Json(new { success = true, message = "Category deleted successfully", category });
        }
    }
}
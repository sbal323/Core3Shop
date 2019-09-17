using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core3Shop.Bl.Contracts;
using Core3Shop.Utility.Consts;
using Microsoft.AspNetCore.Mvc;

namespace Core3Shop.Areas.Admin.Controllers
{
    [Area(AreaNames.Admin)]
    public class UserController : Controller
    {
        private readonly IBlUser _blUser;
        public UserController(IBlUser blUser)
        {
            _blUser = blUser;
        }
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var model = _blUser.GetAll(claims.Value);
            return View(model);
        }
        public IActionResult Lock(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _blUser.Lock(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult UnLock(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _blUser.Unlock(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
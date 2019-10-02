using Core3Shop.Models;
using Core3Shop.Utility.Consts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core3Shop.Dal.Data.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DbInitializer(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void Initialize()
        {
            if (_dbContext.Database.GetPendingMigrations().Count() > 0)
            {
                _dbContext.Database.Migrate();
            }
            if (!_dbContext.Roles.Any(x => x.Name == Roles.Admin))
            {
                _roleManager.CreateAsync(new IdentityRole(Roles.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Roles.Manager)).GetAwaiter().GetResult();
                _userManager.CreateAsync(new ApplicationUser { 
                    UserName= "sbal323@gmail.com",
                    FullName ="Sergey Balog",
                    Email= "sbal323@gmail.com",
                    EmailConfirmed = true,
                    City = "Kiev",
                    State="UA"
                },"!QAZ2wsx").GetAwaiter().GetResult();
                var admin = _dbContext.ApplicationUsers.Where(x => x.Email == "sbal323@gmail.com").FirstOrDefault();
                _userManager.AddToRoleAsync(admin, Roles.Admin).GetAwaiter().GetResult();
            }
        }
    }
}

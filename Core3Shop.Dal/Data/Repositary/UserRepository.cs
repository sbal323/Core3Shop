using Core3Shop.Dal.Data.Repositary.Contracts;
using Core3Shop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Core3Shop.Dal.Data.Repositary
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        private ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext context): base(context)
        {
            _dbContext = context;
        }

        public void LockUser(string userId)
        {
            var user = _dbContext.ApplicationUsers.FirstOrDefault(x => x.Id == userId);
            user.LockoutEnd = DateTime.Now.AddYears(100);
            _dbContext.SaveChanges();
        }

        public void UnlockUser(string userId)
        {
            var user = _dbContext.ApplicationUsers.FirstOrDefault(x => x.Id == userId);
            user.LockoutEnd = null;
            _dbContext.SaveChanges();
        }
    }
}

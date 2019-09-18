
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core3Shop.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        //{
        //    var userIdentity = await manager.CreateAsync(this);
        //    manager.AddClaimAsync(this)

        //    userIdentity. .AddClaim(new Claim("FullName", this.FullName));
        //    return userIdentity;
        //}
    }
}

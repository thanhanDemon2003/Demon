using Demon.Application.Common.Interfaces;
using Demon.Application.Common.Utility;
using Demon.Domain.Entities;
using Demon.Infrastructure.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demon.Infrastructure.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DbInitializer(ApplicationDbContext db,
           UserManager<ApplicationUser> userManager,
           RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public void Initialize()
        {
            try
            {
                //if (_db.Database.GetPendingMigrations().Count() > 0)
                //{
                //    _db.Database.Migrate();
                //}
                //if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
                //{
                //    _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).Wait();
                //    _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).Wait();
                //    _userManager.CreateAsync(new ApplicationUser
                //    {
                //        UserName = "thanhan@demondev.games",
                //        Email = "thanhan@demondev.games",
                //        Name = "Thành An",
                //        NormalizedUserName = "ADMINDEMON",
                //        NormalizedEmail = "THANHAN@DEMONDEV.GAMES",
                //        PhoneNumber = "01234567890",
                //    }, "Demon@123").GetAwaiter().GetResult();

                //    ApplicationUser user = _db.Users.FirstOrDefault(u => u.Email == "thanhan@demondev.games");
                //    _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
                //}

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}

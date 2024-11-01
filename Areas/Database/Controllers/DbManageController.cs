using App.Data;
using App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("/database-manage/[action]")]
    
    public class DbManageController : Controller
    {

        private readonly AppDbContext _dbContext;

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbManageController(AppDbContext dbContext,UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }



        // GET: DbManageController
        public ActionResult Index()
        {
            return View();
        }

        //------------

        [HttpGet]
        public IActionResult DeleteDb(){
            return View();
        }

        [TempData]
        public string StatusMessage{get; set;}

        [HttpPost]
        public async Task<IActionResult> DeleteDbAsync()
        {
             var success = await _dbContext.Database.EnsureDeletedAsync();

            StatusMessage = success ? "Xoa DB thanh cong" : "Khong xoa duoc DB!!!";

             return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Migrate()
        {
            await _dbContext.Database.MigrateAsync();

            StatusMessage =  "Cap nhat Db thanh cong";

             return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> SeedDataAsync(){
            //create role
            var rolenames = typeof(RoleName).GetFields().ToList();
            foreach(var r in rolenames){
                var rolename = (string)r.GetRawConstantValue();
                var rfound = await _roleManager.FindByNameAsync(rolename);
                if(rfound == null){
                    await _roleManager.CreateAsync(new IdentityRole(rolename));
                }
            }

            //admin, pass = admin123, admin@example.com
            var useradmin = await _userManager.FindByEmailAsync("admin");
            if(useradmin == null){
                useradmin = new AppUser(){
                    UserName = "admin",
                    Email = "admin@example.com",
                    EmailConfirmed = true
                };

                await _userManager.CreateAsync(useradmin,"admin123");
                await _userManager.AddToRoleAsync(useradmin, RoleName.Administrator);
            }

            StatusMessage = "Da Seed database";
            return RedirectToAction("Index");
        }

    }
}

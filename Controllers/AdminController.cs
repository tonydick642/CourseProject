using CourseProject.Models;
using CourseProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Controllers
{
    public class AdminController : Controller
    {

        //[Authorize(Roles = "Admin")]/*Role protection for the admin home page, if you havent added users/roles yet comment this out to access admin home*/
        public IActionResult Home() => View();

        SwimSchoolDbContext db;
        public IActionResult AddLesson()
        {
            return View();

        }
        public async Task<IActionResult> AllLesson()
        {
            var lesson = await db.Lessons.ToListAsync();
            return View(lesson);
        }
        UserManager<ApplicationUser> userManager;
        RoleManager<IdentityRole> roleManager;
        public AdminController(SwimSchoolDbContext db,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult AllRole() //view all roles
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult AddRole()// add role method
        {

            return View();
        }

        [HttpPost] //make add role work
        public async Task<IActionResult> AddRole(IdentityRole role)
        {
            var result = await roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("AllRole");
            }
            return View();
        }

        public async Task<IActionResult> AddUserRole(string id)
        {
            var roleDisplay = db.Roles.Select(x => new
            {
                Id = x.Id,
                Value = x.Name
            }).ToList();
            RoleAddUserRoleViewModel vm = new RoleAddUserRoleViewModel();
            var user = await userManager.FindByIdAsync(id);
            vm.User = user;
            vm.RoleList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(roleDisplay, "Id", "Value");
            return View(vm);
        }

        [HttpPost] // make add role button work 
        public async Task<IActionResult> AddUserRole(RoleAddUserRoleViewModel vm)
        {
            var user = await userManager.FindByIdAsync(vm.User.Id);
            var role = await roleManager.FindByIdAsync(vm.Role);
            var result = await userManager.AddToRoleAsync(user, role.Name);
            if (result.Succeeded)
            {
                return RedirectToAction("AllUser", "Admin");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
            var roleDisplay = db.Roles.Select(x => new
            {
                Id = x.Id,
                Value = x.Name
            }).ToList();
            vm.User = user;
            vm.RoleList = new SelectList(roleDisplay, "Id", "Value");
            return View(vm);

        }
        public IActionResult AllUser() //viewing all users
        {
            var users = db.Users.ToList();
            return View(users);
        }

    }
}

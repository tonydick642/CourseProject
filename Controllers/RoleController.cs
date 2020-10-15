﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseProject.Models;
using CourseProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class RoleController : Controller
    {
        SwimSchoolDbContext db;
        UserManager<ApplicationUser> userManager;
        RoleManager<IdentityRole> roleManager;
        public RoleController(SwimSchoolDbContext db,
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

    }

}

﻿using BL.AppServices;
using BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        // GET: Role
        RoleAppService roleAppService = new RoleAppService();

        public ActionResult Index()
        {
            return View(roleAppService.GetAllRoles());
        }
        public ActionResult Create() => View(new RoleViewModel());

        [HttpPost]
        public ActionResult Create( RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid == false)
                return View(roleViewModel);
            roleAppService.Create(roleViewModel.Name);
            return RedirectToAction("index");

        }
        public ActionResult Details(string id)
        {
          
            return View(roleAppService.getAllUsers(id));
          
        }
        public ActionResult Edit(string id)
        {
            return View(roleAppService.GetRoleById(id));
        }
        [HttpPost]
        public ActionResult Edit(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid == false)
                return View(roleViewModel);
            roleAppService.Update(roleViewModel);
            return RedirectToAction("index");

        }

      
     
        public ActionResult Delete(string id)
        {

            roleAppService.DeleteRole(id);
            return RedirectToAction("index");

        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using BL;
using BL.AppServices;
using BL.ViewModels;
using AutoMapper;
using BL.Configurations;
using DAL.Models;

namespace Web.Controllers
{
   [Authorize(Roles ="Admin")]
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryAppService categoryAppService = new CategoryAppService();
        CartAppService CartAppService = new CartAppService();
        ProductAppService ProductAppService = new ProductAppService();
        public ActionResult Index()
        {
            return View(categoryAppService.GetAllCateogries());
        }
        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid == false)
                return View(categoryViewModel);
            categoryAppService.SaveNewCategory(categoryViewModel);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            return View(categoryAppService.GetCategory(id));
        }

        [HttpPost]
        public ActionResult Edit(int id,CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid == false)
                return View(categoryViewModel);
          
            categoryAppService.UpdateCategory(categoryViewModel);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int catID)
        {
            categoryAppService.DeleteCategory(catID);
            return RedirectToAction("Index"); //can not refresh
        }
      
    

    }
}
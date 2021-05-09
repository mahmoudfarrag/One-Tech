using BL.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        CategoryAppService categoryAppService = new CategoryAppService();
        ProductAppService productAppService = new ProductAppService();
        public ActionResult Index()
        {
            ViewBag.cats = categoryAppService.GetAllCateogries();
            return View(productAppService.GetAllProduct().OrderByDescending(p=>p.ID).Take(6).ToList());
        }

     
    }
}
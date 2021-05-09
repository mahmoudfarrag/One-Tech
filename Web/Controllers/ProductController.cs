using AutoMapper;
using BL.AppServices;
using BL.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.Configurations;

using Web.MyHubs;


namespace Web.Controllers
{
    [System.Web.Mvc.Authorize(Roles ="Admin")]
    public class ProductController : Controller
    {
        // GET: Product
        CategoryAppService categoryAppService = new CategoryAppService();
        ProductAppService productAppService = new ProductAppService();
        ReviewsAppService reviewsAppService = new ReviewsAppService();


    
        public ActionResult Index()
        {
            var list = productAppService.GetAllProduct().ToList();
            return View(list);

        }
        public ActionResult AddProduct()
        {
            ViewBag.categories = categoryAppService.GetAllCateogries();
            return View("AddProduct");
        }

        [HttpPost]
        public ActionResult AddProduct(ProductViewModel productViewModel, HttpPostedFileBase image)
        {
            if (ModelState.IsValid == false)
                return View(productViewModel);
            if (image != null && image.ContentLength > 0)
            {
                var fileName = Path.GetFileName(image.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);
                image.SaveAs(path);
                productViewModel.image = fileName;
            }
            productAppService.SaveNewProduct(productViewModel);
            return RedirectToAction("Index");


         
        }
      
        public ActionResult UpdateProduct(int id)
        {
            ProductViewModel product = productAppService.GetPoduct(id);
            ViewBag.categories = categoryAppService.GetAllCateogries();
            return View("UpdateProduct", product);
        }
      
        [HttpPost]
        public ActionResult Update(ProductViewModel productViewModel, HttpPostedFileBase image)
        {
           
            if ( image!= null && image.ContentLength > 0 )
            {
                //user upload new image
                var fileName = Path.GetFileName(image.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);
                image.SaveAs(path);
                productViewModel.image = fileName;
              
            }
         
            productAppService.UpdateProduct(productViewModel);
            //notify update product
            IHubContext productHubContext = GlobalHost.ConnectionManager.GetHubContext<ProductHub>();
            productHubContext.Clients.All.NotifyUpdateProduct(productViewModel);

            return RedirectToAction("Index");
        }
        public ActionResult DeleteProduct(int id)
        {

            productAppService.DeleteProduct(id);
            return RedirectToAction("Index");
        }


        private const int pageSize = 3;
     
        [AllowAnonymous]
        public ActionResult allProducts(int? page)
        {
            ViewBag.cats = categoryAppService.GetAllCateogries();
            ViewBag.actionName = "allProducts";
            int pageNumber = (page ?? 1);
            var list = productAppService.GetAllProduct().ToList().ToPagedList(pageNumber, pageSize);
            return View(list);
        }
        [AllowAnonymous]
        public ActionResult details(int id)
        {
            var rr= reviewsAppService.getproductReview(User.Identity.GetUserId(), id);
            ViewBag.productReview = rr;
            return View(productAppService.GetPoduct(id));
        }
        [AllowAnonymous]
        public ActionResult search(string productToSearch,int ? page)
        {
            ViewBag.cats = categoryAppService.GetAllCateogries();
            ViewBag.productToSearch = productToSearch;
            ViewBag.actionName = "search";
            int pageNumber = (page ?? 1);
           
            List<ProductViewModel> productViewModels = productAppService.SearchFor(productToSearch);
            var list = productViewModels.ToPagedList(pageNumber, pageSize);

            return View("allProducts", list);
        }
        [AllowAnonymous]
        
        public ActionResult getProducts(int id,int ? page)
        {

            ViewBag.cats = categoryAppService.GetAllCateogries();
            //id is category id
            ViewBag.actionName = "getProducts";
            ViewBag.categoryID = id;
            int pageNumber = (page ?? 1);
            var list= productAppService.GetAllProductWhere(id).ToList().ToPagedList(pageNumber, pageSize);
            return View("allProducts",list );

        }
      


    }
}
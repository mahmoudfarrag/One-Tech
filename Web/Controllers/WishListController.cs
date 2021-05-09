using BL.AppServices;
using BL.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize]
    public class WishListController : Controller
    {
        ProductWishListAppService productWishListAppService = new ProductWishListAppService();
        ProductAppService productAppService  = new ProductAppService();
        WishlistAppService wishlistAppService = new WishlistAppService();
        public ActionResult Index()
        {
            //get all products in specfic wishlist
            //firs get cart id of logged user
            var userID = User.Identity.GetUserId();
            var wishListID = wishlistAppService.GetAllWishlists().Where(w => w.ApplicationUserIdentity_Id == userID)
                                                           .Select(w => w.ID).FirstOrDefault();
            var productIDs = productWishListAppService.GetAllProductWishList().Where(w => w.wishlistId == wishListID).Select(wpr => wpr.productId);
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();
            foreach (var proID in productIDs)
            {
                var product = productAppService.GetPoduct(proID);
                productViewModels.Add(product);
            }
            return View(productViewModels);
        }
        [HttpPost]
        public void AddProductToWishList(int id)
        {
            //get wishlist of current logged user
            var userID = User.Identity.GetUserId();
            var wishListID = wishlistAppService.GetAllWishlists().Where(w => w.ApplicationUserIdentity_Id == userID)
                                                           .Select(w => w.ID).FirstOrDefault();
            var productWishListViewModel = new ProductWishListViewModel() { wishlistId = wishListID, productId = id };
            var isExistingProductWishListViewModel = productWishListAppService.GetAllProductWishList()
                                                .FirstOrDefault(w => w.wishlistId == productWishListViewModel.wishlistId && w.productId == productWishListViewModel.productId);

            if (isExistingProductWishListViewModel == null)
                productWishListAppService.SaveNewProductWishlist(productWishListViewModel);
            else
            {
                //this product exist in the wishlist you can not add it again
            }


          

        }
        public ActionResult DeleteFromWishList(int producID)
        {
            var userID = User.Identity.GetUserId();
            var wishListID = wishlistAppService.GetAllWishlists().Where(w => w.ApplicationUserIdentity_Id == userID)
                                                           .Select(w => w.ID).FirstOrDefault();
            var productWishlistViewModel = new ProductWishListViewModel() { wishlistId = wishListID, productId = producID };
            var deletedProductWishList = productWishListAppService.GetAllProductWishList()
                                                 .FirstOrDefault(w => w.wishlistId == productWishlistViewModel.wishlistId && w.productId == productWishlistViewModel.productId);

            productWishListAppService.DeleteProductWishList(deletedProductWishList.ID);
            return RedirectToAction("Index");
        }

    }
}
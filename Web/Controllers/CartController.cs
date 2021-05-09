using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.AppServices;
using BL.ViewModels;
using Microsoft.AspNet.Identity;

namespace Web.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        ProductCartAppService productCartAppService = new ProductCartAppService();
        ProductAppService productAppService = new ProductAppService();
        PaymentAppService paymentAppService = new PaymentAppService();
        CartAppService cartAppService = new CartAppService(); 
    
        // GET: Cart
        public ActionResult Index()
        {

            //get all products in specfic cart
            //firs get cart id of logged user
            var userID = User.Identity.GetUserId();
            var cartID = cartAppService.GetAllCarts().Where(c => c.ApplicationUserIdentity_Id == userID)
                                                           .Select(c => c.ID).FirstOrDefault();
            var productIDs = productCartAppService.GetAllProductCart().Where(pc => pc.cartId == cartID).Select(prc => prc.productId);
            List<ProductViewModel> productViewModels=new List<ProductViewModel> ();
            foreach (var proID in productIDs)
            {
                var product = productAppService.GetPoduct(proID);
                productViewModels.Add(product);
            }
            CartAndPaymentInfoViewModel cardDetailsViewModel = new CartAndPaymentInfoViewModel
            {
                paymentViewModels = paymentAppService.GetPaymentsOfUser(userID),
                productViewModels=productViewModels

            };
            //ViewBag.cardDetails = cardDetailsViewModel;
            return View(cardDetailsViewModel);
        }

      
        [HttpPost]
        public void AddProductToCart(int id)
        {
            //get cart of current logged user
            var userID = User.Identity.GetUserId();
            var cartID = cartAppService.GetAllCarts().Where(c => c.ApplicationUserIdentity_Id == userID)
                                                           .Select(c => c.ID).FirstOrDefault();
            var productCartViewModel = new ProductCartViewModel() { cartId = cartID, productId = id };
             var isExistingProductCartViewModel  = productCartAppService.GetAllProductCart()
                                                  .FirstOrDefault(c=>c.cartId == productCartViewModel.cartId && c.productId == productCartViewModel.productId);
           
            if(isExistingProductCartViewModel == null)
                productCartAppService.SaveNewProductCart(productCartViewModel);
            else
            {
                //this product exist in the cart you can not add it again
            }
            //return RedirectToAction("Index");

        }
        public ActionResult DeleteFromCart(int productID)
        {
            var userID = User.Identity.GetUserId();
            var cartID = cartAppService.GetAllCarts().Where(c => c.ApplicationUserIdentity_Id == userID)
                                                           .Select(c => c.ID).FirstOrDefault();
            var productCartViewModel = new ProductCartViewModel() { cartId = cartID, productId = productID };
            var deletedProductCart = productCartAppService.GetAllProductCart()
                                                 .FirstOrDefault(c => c.cartId == productCartViewModel.cartId && c.productId == productCartViewModel.productId);

            productCartAppService.DeleteProductCart(deletedProductCart.ID);
            return RedirectToAction("Index");
        }
     


    }
}
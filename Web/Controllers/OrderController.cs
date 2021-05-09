using AutoMapper;
using BL.AppServices;
using BL.Configurations;
using BL.ViewModels;
using DAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.MyHubs;

namespace Web.Controllers
{
   [System.Web.Mvc.Authorize]
    public class OrderController : Controller
    {
        // GET: Order
        OrderAppService orderAppService = new OrderAppService();
        CartAppService cartAppService = new CartAppService();
        ProductCartAppService productCartAppService = new ProductCartAppService();
        ProductAppService productAppService = new ProductAppService();
        OrderProductAppService orderProductAppService = new OrderProductAppService();
        [System.Web.Mvc.Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
           
            return View(orderAppService.GetAllOrder());
        }
  


       [HttpPost]
       
        public ActionResult makeOrder(int [] quantities, double totalOrderPrice)
        {

            //get cart id of current logged user
            // CartViewModel cartViewModel = cartAppService.GetCart(5);
            var userID = User.Identity.GetUserId();
            var cartID = cartAppService.GetAllCarts().Where(c => c.ApplicationUserIdentity_Id == userID)
                                                           .Select(c => c.ID).FirstOrDefault();
            //get product ids from this card
            var prodIds = productCartAppService.GetAllProductCart().Where(pc => pc.cartId == cartID)
                                                                 .Select(pc => pc.productId).ToList();

            OrderViewModel orderViewModel = new OrderViewModel { 
             date=DateTime.Now.ToString(),
          
             totalPrice =totalOrderPrice,
            ApplicationUserIdentity_Id=userID
        
            };
            orderAppService.SaveNewOrder(orderViewModel);
           var lastOrder= orderAppService.GetAllOrder().Select(o=>o.Id).LastOrDefault();
           
            //get know details of each product
            for(int i = 0; i < prodIds.Count; i++)
            {
               
                var productViewModel = productAppService.GetPoduct(prodIds[i]);
                double totOrder = productViewModel.Price * quantities[i];
                double AfterDiscount = totOrder - totOrder * (productViewModel.Discount / 100);
                OrderProductViewModel orderProductViewModel = new OrderProductViewModel
                {
                    orderID = lastOrder,
                    ProductID = productViewModel.ID,
                    productDiscount = productViewModel.Discount,
                    productQuantity =quantities[i],
                    productTotal= totOrder,
                    ProductNetPrice=AfterDiscount
                };
                orderProductAppService.SaveNewOrderProduct(orderProductViewModel);
                //decrease amount of product
                //productViewModel.Quantity -= quantities[i];
                //productAppService.UpdateProduct(productViewModel);
                productAppService.DecreaseQuantity(productViewModel.ID, quantities[i]);
              
              
                 var productCartID = productCartAppService.GetAllProductCart()
                                                        .Where(prc => prc.cartId == cartID&& prc.productId == productViewModel.ID)
                                                        .Select(prc => prc.ID).FirstOrDefault();
                productCartAppService.DeleteProductCart(productCartID);

            }

            //notify admin by the product that had been bought
              var productQuantities = new List<ProductQuantitiesCheckoutViewModel>();
            for(int i = 0; i < quantities.Length; i++)
            {
                productQuantities.Add(
                new ProductQuantitiesCheckoutViewModel
                { ProductID = prodIds[i],
                  Quantity=quantities[i]
                });
            }

            IHubContext productHubContext = GlobalHost.ConnectionManager.GetHubContext<ProductHub>();
            productHubContext.Clients.All.NotifyAdminAfterCheckout(productQuantities);
            return RedirectToAction("index","home");
        }
        public ActionResult Details(int id)
        {

            return View(orderProductAppService.GetAllOrderProduct().Where(op => op.orderID == id).ToList());
        }

        
    }
    
}
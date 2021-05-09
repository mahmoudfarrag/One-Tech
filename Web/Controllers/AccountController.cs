using BL.AppServices;
using BL.ViewModels;
using DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.ViewModels;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        AccountAppService accountAppService = new AccountAppService();
        CartAppService cartAppService = new CartAppService();
        WishlistAppService wishlistAppService = new WishlistAppService();
        RoleAppService roleAppService = new RoleAppService();
        // GET: Account
        public ActionResult Register()
        {
            ViewBag.roles = roleAppService.GetAllRoles().Select(c=>c.Name).ToList();
            return View(new RegisterViewodel());

        }
        
    
 

        [HttpPost]
        public ActionResult Register(RegisterViewodel user)
        {

            ViewBag.roles = roleAppService.GetAllRoles().Select(c => c.Name).ToList();
            if (ModelState.IsValid == false)
            {
                return View(user);
            }
            IdentityResult result = accountAppService.Register(user);
            if (result.Succeeded)
            {
                IAuthenticationManager owinMAnager = HttpContext.GetOwinContext().Authentication;
                //SignIn
                SignInManager<ApplicationUserIdentity, string> signinmanager =
                    new SignInManager<ApplicationUserIdentity, string>(
                        new ApplicationUserManager(), owinMAnager
                        );

                ApplicationUserIdentity identityUser = accountAppService.Find(user.UserName, user.PasswordHash);
                signinmanager.SignIn(identityUser, true, true);
                //create cart for new user
                CartViewModel cartViewModel = new CartViewModel() { ApplicationUserIdentity_Id = identityUser.Id };
                cartAppService.SaveNewCart(cartViewModel);

                WishlistViewModel wishlistViewModel = new WishlistViewModel() { ApplicationUserIdentity_Id = identityUser.Id };
                wishlistAppService.SaveNewWishlist(wishlistViewModel);

                accountAppService.AssignToRole(identityUser.Id, user.RoleName);
                return RedirectToAction("login", "Account");
            }
            else
            {
                ModelState.AddModelError("UserName", "Username already exist");
                return View(user);
            }
        }
        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        {
            if (ModelState.IsValid == false)
            {
                return View(user);
            }
            ApplicationUserIdentity identityUser = accountAppService.Find(user.UserName, user.PasswordHash);

            if (identityUser != null )
            {
                IAuthenticationManager owinMAnager = HttpContext.GetOwinContext().Authentication;
                //SignIn
                SignInManager<ApplicationUserIdentity, string> signinmanager =
                    new SignInManager<ApplicationUserIdentity, string>(
                        new ApplicationUserManager(), owinMAnager
                        );
                signinmanager.SignIn(identityUser, true, true);
                return RedirectToAction("Index", "home");
            }
            else
            {
                ModelState.AddModelError("", "Not Valid Username & Password");
                return View(user);
            }

        }
        [Authorize]
        public ActionResult Logout()
        {
            IAuthenticationManager owinMAnager = HttpContext.GetOwinContext().Authentication;
            owinMAnager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login");

        }
        [HttpGet]
        [Authorize]
        public ActionResult Edit(string id)
        {
            

            return View(accountAppService.GetAccountById(id));
        }
        [HttpPost]
        public ActionResult Edit(RegisterViewodel registerViewodel)
        {
            if (!ModelState.IsValid) 
              return View(registerViewodel);
            registerViewodel.PasswordHash = registerViewodel.ConfirmPassword = null;
            accountAppService.Update(registerViewodel);

            return RedirectToAction("index", "home");
            

        }
       
        public ActionResult index()
        {
           
            return View(accountAppService.GetAllAccounts());
        }
        public ActionResult Details(string id)
        {

            return View(accountAppService.GetAccountById(id));
        }

     
        public void Delete(string id)
        {
            //cartAppService.GetCart(3);
            accountAppService.DeleteAccount(id);


        }
   
        public void UpdatePassword(string userID,string newPassword)
        {
            accountAppService.UpdatePassword(userID, newPassword);
        }


    }
}
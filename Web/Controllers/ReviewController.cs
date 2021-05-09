using BL.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.AppServices;

namespace Web.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {
        // GET: Review
       
        ReviewsAppService reviewsAppService = new ReviewsAppService();
        [HttpPost]
        public void addRating(int prodID, string description, int rating)
        {
            ReviewsViewModel reviewsViewModel = new ReviewsViewModel
            {

                Description = description,
                productID = prodID,
                rating = rating,
                userID = User.Identity.GetUserId()
            };
            reviewsAppService.AddOrUpdateReview(reviewsViewModel);

        }
        


    }
}
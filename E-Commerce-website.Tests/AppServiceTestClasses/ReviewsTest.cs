using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.ViewModels;
using BL.AppServices;

namespace E_Commerce_website.Tests
{
    public class ReviewsTest
    {

        ReviewsAppService reviewsAppService;
        [SetUp]
        public void SetUp()
        {
            reviewsAppService = new ReviewsAppService();
        }
        [TestCaseSource(typeof(ReviewsItems))]
        public bool AddOrUpdateReview_Test(int prodID,string userID,string description,int rating)
        {
            ReviewsViewModel reviewsViewModel = new ReviewsViewModel
            {
                productID = prodID,
                Description = description,
                userID = userID,
                rating=rating
            };
            return reviewsAppService.AddOrUpdateReview(reviewsViewModel);
        }

        [Test]
        public void AddOrUpdateReview_Test_throws_Exception()
        {
            ReviewsViewModel reviewsViewModel = null;
            Assert.That(() => reviewsAppService.AddOrUpdateReview(reviewsViewModel), Throws.TypeOf<ArgumentNullException>());


        }
    }
}

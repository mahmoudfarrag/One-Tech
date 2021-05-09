using BL.AppServices;
using BL.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_website.Tests.AppServiceTestClasses
{
    public class WishlistTest
    {
        WishlistAppService wishlistAppService;
        [SetUp]
        public void SetUp()
        {
            wishlistAppService = new WishlistAppService();
        }

        [Test]
        public void SaveNewWishlist_ThrowException_Test()
        {
            WishlistViewModel wishlistViewModel = null;
            Assert.That(() => wishlistAppService.SaveNewWishlist(wishlistViewModel), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void GetWishlist_ThrowException_Test()
        {
            int wishlistID = -1;
            Assert.That(() => wishlistAppService.GetWishlist(wishlistID), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void DeleteWishlist_ThrowException_Test()
        {
            int wishlistID = -1;
            Assert.That(() => wishlistAppService.DeleteWishlist(wishlistID), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void DeleteWishlist_Test()
        {
            int wishlistID = 1;
            var res = wishlistAppService.DeleteWishlist(wishlistID);
            Assert.That(res, Is.EqualTo(true));
        }

        [Test]
        public void GetWishlist_Test()
        {
            int wishlistID = 7;
            var res = wishlistAppService.GetWishlist(wishlistID);
            Assert.That(res, Is.Not.Null);
        }

    }
}

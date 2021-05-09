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
    public class CartTest
    {
        CartAppService cartAppService;
        [SetUp]
        public void SetUp()
        {
            cartAppService = new CartAppService();
        }

        [Test]
        public void SaveNewCart_ThrowException_Test()
        {
            CartViewModel cartViewModel = null;
            Assert.That(() => cartAppService.SaveNewCart(cartViewModel), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void GetCart_ThrowException_Test()
        {
            int cartID = -1;
            Assert.That(() => cartAppService.GetCart(cartID), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void DeleteCart_ThrowException_Test()
        {
            int cartID = -1;
            Assert.That(() => cartAppService.DeleteCart(cartID), Throws.TypeOf<ArgumentNullException>());
        }


        [Test]
        public void DeleteCart_Test()
        {
            int cartID = 1;
            var res = cartAppService.DeleteCart(cartID);
            Assert.That(res, Is.EqualTo(true));
        }

        [Test]
        public void GetCart_Test()
        {
            int cartID = 5;
            var res = cartAppService.GetCart(cartID);
            Assert.That(res, Is.Not.Null);
        }

    }
}

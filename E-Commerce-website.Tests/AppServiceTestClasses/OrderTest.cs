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
   public class OrderTest
    {
        OrderAppService orderAppService;

        [SetUp]
        public void Setup()
        {
            orderAppService = new OrderAppService();
        }

        [TestCase(0)]
        public void GetOrderById_Test_throwException_When_ID_Equal_Zero(int id)
        {
            Assert.That(() => orderAppService.GetOrder(id),
            Throws.TypeOf<ArgumentOutOfRangeException>());

        }
        [TestCase(-10)]
        public void GetOrderById_Test_throwException_When_ID_Equal_Negative(int id)
        {
            Assert.That(() => orderAppService.GetOrder(id),
            Throws.TypeOf<ArgumentOutOfRangeException>());

        }

        [Test]
        public void SaveNewOrderTest__throwException_When_ViewModel_Equal_Null()
        {
            Assert.That(() => orderAppService.SaveNewOrder(null),
            Throws.TypeOf<ArgumentNullException>());
        }

        [TestCase(null)]
        [TestCase("")]
        public void SaveNewOrderTest_throwException_When_UserID_Equal_NullOrEmpty(string userid)
        {
            OrderViewModel Order = new OrderViewModel() { ApplicationUserIdentity_Id = userid };
            Assert.That(() => orderAppService.SaveNewOrder(Order),
             Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void UpdateOrderTest_throwException_When_ViewModel_Equal_Null()
        {
            Assert.That(() => orderAppService.UpdateOrder(null), Throws.TypeOf<ArgumentNullException>());
        }

        [TestCase(null)]
        [TestCase("")]
        public void UpdateOrderTest_throwException_When_UserID_Equal_NullOrEmpty(string userid)
        {
            OrderViewModel Order = new OrderViewModel() { ApplicationUserIdentity_Id = userid };
            Assert.That(() => orderAppService.UpdateOrder(Order), 
                Throws.TypeOf<ArgumentException>());
        }

        [TestCase(0)]
        public void DeleteOrderTest_throwException_When_ID_Equal_Zero(int id)
        {
            Assert.That(() => orderAppService.DeleteOrder(id), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [TestCase(-1)]
        public void DeleteOrderTest_throwException_When_ID_Equal_Negative(int id)
        {
            Assert.That(() => orderAppService.DeleteOrder(id), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CheckOrderExistsTest_throwException_When_ViewModel_Equal_Null()
        {
            Assert.That(() => orderAppService.CheckOrderExists(null), Throws.TypeOf<ArgumentNullException>());
        }
    }
}

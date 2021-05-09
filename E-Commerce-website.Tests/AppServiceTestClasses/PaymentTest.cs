//using AutoMapper;
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
    public class PaymentTest
    {
        PaymentAppService paymentAppService;

        [SetUp]
        public void SetUp()
        {
            paymentAppService = new PaymentAppService();
        }

        [TestCase(0)]
        public void GetPaymentById_Test_throwException_When_ID_Equal_Zero(int id)
        {
            Assert.That(() => paymentAppService.GetPayment(id),
            Throws.TypeOf<ArgumentOutOfRangeException>());

        }
        [TestCase(-10)]
        public void GetPaymentById_Test_throwException_When_ID_Equal_Negative(int id)
        {
            Assert.That(() => paymentAppService.GetPayment(id),
            Throws.TypeOf<ArgumentOutOfRangeException>());

        }

        [Test]
        public void SaveNewPaymentTest__throwException_When_ViewModel_Equal_Null()
        {
            Assert.That(() => paymentAppService.SaveNewPayment(null),
            Throws.TypeOf<ArgumentNullException>());
        }

        [TestCase(null)]
        [TestCase("")]
        public void SaveNewPaymentTest_throwException_When_UserID_Equal_NullOrEmpty(string userid)
        {
            PaymentViewModel payment = new PaymentViewModel() { ApplicationUserIdentity_Id = userid };
            Assert.That(() => paymentAppService.SaveNewPayment(payment),
             Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void UpdatePaymentTest_throwException_When_ViewModel_Equal_Null()
        {
            Assert.That(() => paymentAppService.UpdatePayment(null), Throws.TypeOf<ArgumentNullException>());
        }

        [TestCase(null)]
        [TestCase("")]
        public void UpdatePaymentTest_throwException_When_UserID_Equal_NullOrEmpty(string userid)
        {
            PaymentViewModel payment = new PaymentViewModel() { ApplicationUserIdentity_Id = userid };
            Assert.That(() => paymentAppService.UpdatePayment(payment),
                Throws.TypeOf<ArgumentException>());
        }

        [TestCase(0)]
        public void DeletePaymentTest_throwException_When_ID_Equal_Zero(int id)
        {
            Assert.That(() => paymentAppService.DeletePayment(id), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [TestCase(-1)]
        public void DeletePaymentTest_throwException_When_ID_Equal_Negative(int id)
        {
            Assert.That(() => paymentAppService.DeletePayment(id), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CheckPaymentExistsTest_throwException_When_ViewModel_Equal_Null()
        {
            Assert.That(() => paymentAppService.CheckPaymentExists(null), Throws.TypeOf<ArgumentNullException>());
        }
    }
}

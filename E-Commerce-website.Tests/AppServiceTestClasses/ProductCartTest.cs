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
    class ProductCartTest
    {
        ProductCartAppService productCartAppService;
        [SetUp]
        public void SetUp()
        {
            productCartAppService = new ProductCartAppService();
        }

        [Test]
     
        public void SaveNewProductCart_Test()
        {
            ProductCartViewModel productCartViewModel = new ProductCartViewModel()
            {
               cartId=8,
               productId=16,
            };

            int countBeforeAdding = productCartAppService.GetAllProductCart().Count;
            productCartAppService.SaveNewProductCart(productCartViewModel);
            int countAfterAdding = productCartAppService.GetAllProductCart().Count;

            Assert.That(countAfterAdding, Is.EqualTo(countBeforeAdding + 1));

        }

        [Test]
        public void SaveNewProductCart_Test_throws_Exception_If_ProductViewModel_IsNull()
        {
            ProductCartViewModel productCartViewModel = null;
            Assert.That(() => productCartAppService.SaveNewProductCart(productCartViewModel), Throws.TypeOf<ArgumentNullException>());

        }
        [Test]
        public void DeleteProductCart_Test_throwException_When_ID_LessOrEqualToZero()
        {
            int id = -1;
            Assert.That(() => productCartAppService.DeleteProductCart(id), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void DeleteProductCart_Returns_True_If_Deleted()
        {
            var Deleteres = productCartAppService.DeleteProductCart(5);
            Assert.That(Deleteres, Is.True);

        }

    }
}

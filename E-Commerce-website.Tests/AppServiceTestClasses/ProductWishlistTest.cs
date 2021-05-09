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
    class ProductWishlistTest
    {
        ProductWishListAppService productWishListAppService;
        [SetUp]
        public void SetUp()
        {
            productWishListAppService = new ProductWishListAppService();
        }

        [Test]

        public void SaveNewProductWishList_Test()
        {
            ProductWishListViewModel productWishListViewModel = new ProductWishListViewModel()
            {
                wishlistId = 7,
                productId = 16,
            };

            int countBeforeAdding = productWishListAppService.GetAllProductWishList().Count;
            productWishListAppService.SaveNewProductWishlist(productWishListViewModel);
            int countAfterAdding = productWishListAppService.GetAllProductWishList().Count;

            Assert.That(countAfterAdding, Is.EqualTo(countBeforeAdding + 1));

        }

        [Test]
        public void SaveNewProductWishList_Test_throws_Exception_If_ProductViewModel_IsNull()
        {
            ProductWishListViewModel productWishListViewModel = null;
            Assert.That(() => productWishListAppService.SaveNewProductWishlist(productWishListViewModel), Throws.TypeOf<ArgumentNullException>());

        }

        [Test]
        public void DeleteProductWishList_Test_throwException_When_ID_LessOrEqualToZero()
        {
            int id = -1;
            Assert.That(() => productWishListAppService.DeleteProductWishList(id), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void DeleteProductWishlist_Returns_True_If_Deleted()
        {
            var Deleteres = productWishListAppService.DeleteProductWishList(23);
            Assert.That(Deleteres, Is.True);

        }

    }
}

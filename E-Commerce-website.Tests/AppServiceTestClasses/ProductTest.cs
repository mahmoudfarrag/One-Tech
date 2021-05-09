using BL.AppServices;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.ViewModels;
using E_Commerce_website.Tests.TestMappingClasses;
using E_Commerce_website.Tests.JsonReaders;

namespace E_Commerce_website.Tests.AppServiceTestClasses
{
    class ProductTest
    {
        ProductAppService product;

        [SetUp]
        public void setUp()
        {
            product = new ProductAppService();

        }
        [TestCase(26)]
        [TestCase(27)]
        [TestCase(28)]
        public void checkProductExists_Test(int id)
        {
           
            var prod = product.GetPoduct(id);
            product.CheckProductExists(prod);
            Assert.That(prod, Is.Not.Null);

        }
        public void checkProductExists_Test2()
        {
            int id = -2;
            var prod = product.GetPoduct(id);
            Assert.That(prod, Is.Null);

        }
        [TestCaseSource(typeof(Product))]
        public bool SaveNewProduct_Test(ProductViewModel p)
        {
          return product.SaveNewProduct(p);
      
        }
        public void GetAllProductCount_Test()
        {
            //product.SaveNewProduct(new BL.ViewModels.ProductViewModel() { Name = "P1", Color = "Red", Description = "Very SMart", Price = 333, Discount = 1000, Quantity = 4 });
            //product.SaveNewProduct(new BL.ViewModels.ProductViewModel() { Name = "P1", Color = "Red", Description = "Very SMart", Price = 333, Discount = 1000, Quantity = 4 });

            var products = product.GetAllProduct();

            Assert.AreEqual(products.Count, 2);

        }
        public void UpdateProduct_Test(int id)
        {
            var oldProduct = product.GetPoduct(id);
            oldProduct.Discount = 200;
            bool res = product.UpdateProduct(oldProduct);
            Assert.AreEqual(res, true);
        }
        [TestCase(26, 3, 17)]
        [TestCase(27, 1, 19)]
        public void DecreaseQuantity_Test(int id, int quantity, int expectedQuantity)

        {
            var oldProduct = product.GetPoduct(id);
            product.DecreaseQuantity(id, quantity);
            Assert.AreEqual(oldProduct.Quantity, expectedQuantity);

        }
        public void SaveNewProduct_Test_throwsException_if_null()
        {
            ProductViewModel p = null;
            Assert.That(() => product.SaveNewProduct(p), Throws.TypeOf<ArgumentNullException>());

        }
    }
}

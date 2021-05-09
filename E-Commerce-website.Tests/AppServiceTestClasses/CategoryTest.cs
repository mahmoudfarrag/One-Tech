using BL.AppServices;
using BL.ViewModels;
using E_Commerce_website.Tests.JsonReaders;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_website.Tests.AppServiceTestClasses
{
    class CategoryTest
    {
        CategoryAppService category;
        [SetUp]
        public void setUp()
        {
            category = new CategoryAppService();

        }
        [TestCaseSource(typeof(Categories))]
        public bool SaveNewCategory_Test(CategoryViewModel c)
        {
            return category.SaveNewCategory(c);
        }
        [Test]
        public void GetCategory_Test()
        {
            int id = 19;
            var cat = category.GetCategory(id);
            Assert.That(cat, Is.Not.Null);

        }
        [Test]
        public void GetCategory_Test2()
        {
            int id = -4;
            var cat = category.GetCategory(id);
            Assert.That(cat, Is.Null);

        }
        [TestCase(23)]
      
        public void DeleteCategory_Test(int id)
        {
            var cat = category.GetCategory(id);
            bool res = category.DeleteCategory(id);
            Assert.AreEqual(true, res);
        }
        [TestCase(19)]
        [TestCase(20)]
        [TestCase(21)]
        public void CheckCategoryExists_Test(int id)
        {
            var Cat = category.GetCategory(id);
          bool res=category.CheckCategoryExists(Cat);
            Assert.AreEqual(true, res);
            
        }
        [TestCase(20)]
        public void UpdateCategory_test(int id)
        {
            var cat = category.GetCategory(id);
            bool res=category.UpdateCategory(cat);
            Assert.AreEqual(true, res);

        }
      
        [Test]
        public void SaveNewProduct_Test_throwsException_if_null()
        {
            CategoryViewModel c = null;
            Assert.That(() => category.SaveNewCategory(c), Throws.TypeOf<ArgumentNullException>());

        }
    }
}

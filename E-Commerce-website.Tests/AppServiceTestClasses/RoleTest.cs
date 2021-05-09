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
    class RoleTest
    {
        RoleAppService roleAppService;
        [SetUp]
        public void SetUp()
        {
            roleAppService = new RoleAppService();
        }

        [TestCase(null)]
        [TestCase("")]
        public void GetRoleByIdTest_throwException_When_ID_Equal_NullOrEmpty(string id)
        {
            Assert.That(() => roleAppService.GetRoleById(id),
             Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Create_AddAlredyExistRole_Test()
        {
            var result = roleAppService.Create("Admin");

            Assert.That(result.Succeeded, Is.False);
        }

        [Test]
        public void UpdateRoleTest_throwException_When_ViewModel_Equal_Null()
        {
            Assert.That(() => roleAppService.Update(null), Throws.TypeOf<ArgumentNullException>());
        }

        [TestCase(null)]
        [TestCase("")]
        public void UpdateRoleTest_throwException_When_ID_Equal_NullOrEmpty(string id)
        {
            RoleViewModel role = new RoleViewModel() { Id = id };
            Assert.That(() => roleAppService.Update(role),
                Throws.TypeOf<ArgumentException>());
        }

        [TestCase(null)]
        [TestCase("")]
        public void DeleteRoleTest_throwException_When_ID_Equal_NullOrEmpty(string id)
        {
            Assert.That(() => roleAppService.DeleteRole(id),
             Throws.TypeOf<ArgumentNullException>());
        }

    }
}

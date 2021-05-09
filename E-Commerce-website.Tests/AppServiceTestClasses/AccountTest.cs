using BL.AppServices;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.ViewModels;
using DAL;

namespace E_Commerce_website.Tests
{
    public class AccountTest
    {
        AccountAppService accountAppService;
        [SetUp]
        public void SetUp()
        {
            accountAppService = new AccountAppService();
        }

        [Test]
        public void GetAccountById_Test_throwException_When_ID_Equal_Null()
        {
            string id = null;
            Assert.That(() => accountAppService.GetAccountById(id), Throws.TypeOf<ArgumentNullException>());
        }
      
        [Test]
        public void GetAccountById_Returns_Registerd_User_Test()
        {
            string id = "083266aa-51cf-47da-836d-6986d04b73e9";
            var res = accountAppService.GetAccountById(id);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public void DeleteAccount_Test_throwException_When_ID_Equal_Null()
        {
            string id = null;
            Assert.That(() => accountAppService.DeleteAccount(id), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void DeleteAccount_Returns_True_If_Deleted()
        {
            string id = "ddc3fd50-4b43-4f35-84f5-4804efd6d197";
            var DeleteAccount = accountAppService.GetAccountById(id);
            int countBeforeDelete = accountAppService.GetAllAccounts().Count;
            var DeleteResult = accountAppService.DeleteAccount(id);
            int countAfterDelete = accountAppService.GetAllAccounts().Count;
            //reset this accout isdeleteto flase
            DeleteAccount.isDeleted = false;
            accountAppService.Update(DeleteAccount);
            Assert.That(countAfterDelete, Is.EqualTo(countBeforeDelete-1));
           
        }

        [Test]
        public void Find_Returns_Not_Null_If_Exists()
        {
            var userName = "gogogo";
            var password = "123456";
            var findResult = accountAppService.Find(userName, password);
            Assert.That(findResult, Is.Not.Null);

        }
        [Test]
        public void Find_Returns_Null_If_Not_Exists()
        {
            var userName = "omer123";
            var password = "123456";
            var findResult = accountAppService.Find(userName, password);
            Assert.That(findResult, Is.Null);

        }
        [Test]
        [Ignore("for change")]
        public void RegisterAccount_Test()
        {
            RegisterViewodel user = new RegisterViewodel()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "test@gmail.com",
                FirstName = "UserTest",
                LastName = "UserTest",
                UserName = "UserTest",
                PasswordHash = "123456",
                BirthDate = DateTime.Now,
                isDeleted = false,
                Gender = "Male",
                Address = "Admin",
            };
   
            int countBeforeRegister = accountAppService.GetAllAccounts().Count;
            accountAppService.Register(user);
            int countAfterRegister = accountAppService.GetAllAccounts().Count;
       
            Assert.That(countAfterRegister, Is.EqualTo(countBeforeRegister + 1));

        }

        [Test]
        public void AssignToRole_Test_throws_Exception_If_userid_Or_roleName_IsNull()
        {
            string userId = null;
            string roleName = null;
            Assert.That(() => accountAppService.AssignToRole(userId,roleName), Throws.TypeOf<ArgumentNullException>());

        }
     
        [Test]
        public void AssignToRole_Test_Return_Not_null_If_Assign_Succseed()
        {
            string userId = "a104cce7-765a-4bee-a862-7fa09eda1202";
            string roleName = "Guest22";
            var AssignResult=accountAppService.AssignToRole(userId, roleName);
            Assert.That(AssignResult, Is.Not.Null);

        }



    }
}

using BL.Bases;
using BL.ViewModels;
using DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class AccountAppService : AppServiceBase
    {
        //Login
        public List<RegisterViewodel> GetAllAccounts()
        {
            return Mapper.Map<List<RegisterViewodel>>(TheUnitOfWork.Account.GetAllAccounts().Where(ac=>ac.isDeleted==false));
        }
        public RegisterViewodel GetAccountById(string id)
        {
            if (id == null)
                throw new ArgumentNullException();
            return Mapper.Map<RegisterViewodel>(TheUnitOfWork.Account.GetAccountById(id));
         
        }
        public bool DeleteAccount(string id)
        {
            if (id == null)
                throw new ArgumentNullException();
            bool result = false;
            ApplicationUserIdentity user = TheUnitOfWork.Account.GetAccountById(id);
            user.isDeleted = true;
            TheUnitOfWork.Account.Update(user);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }
        public ApplicationUserIdentity Find(string name, string password)
        {
            var user = TheUnitOfWork.Account.Find(name, password);
           
            if( user != null && user.isDeleted == false)
                  return user;
            return null;
        }
        public IdentityResult Register(RegisterViewodel user)
        {
          
            ApplicationUserIdentity identityUser = Mapper.Map<RegisterViewodel, ApplicationUserIdentity>(user);
            return TheUnitOfWork.Account.Register(identityUser);

        }
        public IdentityResult AssignToRole(string userid, string rolename)
        {
            if (userid == null || rolename == null)
                throw new ArgumentNullException();
            return TheUnitOfWork.Account.AssignToRole(userid, rolename);


        }
        public bool UpdatePassword(string userID,string newPassword)
        {
            //    ApplicationUserIdentity identityUser = TheUnitOfWork.Account.FindById(user.Id);

            //    Mapper.Map(user, identityUser);

            //    return TheUnitOfWork.Account.UpdateAccount(identityUser);


            ApplicationUserIdentity identityUser = TheUnitOfWork.Account.FindById(userID);
            identityUser.PasswordHash = newPassword;
            return TheUnitOfWork.Account.updatePassword(identityUser);

        }

        public bool Update(RegisterViewodel user)
        {
        //    ApplicationUserIdentity identityUser = TheUnitOfWork.Account.FindById(user.Id);
      
        //    Mapper.Map(user, identityUser);
        
        //    return TheUnitOfWork.Account.UpdateAccount(identityUser);


            ApplicationUserIdentity identityUser = TheUnitOfWork.Account.FindById(user.Id);
            var oldPassword = identityUser.PasswordHash;
            Mapper.Map(user, identityUser);
            identityUser.PasswordHash = oldPassword;
            return TheUnitOfWork.Account.UpdateAccount(identityUser);

        }

    }
}

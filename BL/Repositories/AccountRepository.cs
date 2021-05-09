using BL.Bases;
using DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL.Repositories
{
    public class AccountRepository: BaseRepository<ApplicationUserIdentity>
    {
        ApplicationUserManager manager;
      

        public AccountRepository(DbContext db) : base(db)
        {
            manager = new ApplicationUserManager(db);
           
        }
        public ApplicationUserIdentity GetAccountById(string id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }
        public List<ApplicationUserIdentity> GetAllAccounts()
        {
            return GetAll().ToList();
        }
        public ApplicationUserIdentity FindById(string id)
        {

            ApplicationUserIdentity result = manager.FindById(id);

            return result;

        }
        public ApplicationUserIdentity Find(string username, string password)
        {

            ApplicationUserIdentity result = manager.Find(username, password);
          
            return result;

        }
        public IdentityResult Register(ApplicationUserIdentity user)
        {
            user.Id = Guid.NewGuid().ToString();
            IdentityResult result;
            try
            {
                result = manager.Create(user, user.PasswordHash);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

          
           // manager.AddToRole(user.Id,"Admin");
            return result;
        }
        public IdentityResult AssignToRole(string userid, string rolename)
        {
            IdentityResult result = manager.AddToRole(userid, rolename);
            return result;

        }
        public bool updatePassword(ApplicationUserIdentity user)
        {
            user.PasswordHash = manager.PasswordHasher.HashPassword(user.PasswordHash);
            IdentityResult result = manager.Update(user);
            return true;
        }
       
        public  bool UpdateAccount(ApplicationUserIdentity user)
        {

            //user.PasswordHash = manager.PasswordHasher.HashPassword(user.PasswordHash);
            //try
            //{

            //    IdentityResult result = manager.Update(user);
            //}
            //catch (Exception e)
            //{


            //}
            IdentityResult result = manager.Update(user);



            return true;
        }
    }
}

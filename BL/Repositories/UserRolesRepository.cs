using BL.Bases;
using DAL;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    class UserRolesRepository:BaseRepository<IdentityUserRole>
    {
        ApplicationRoleManager manager;

        public UserRolesRepository(DbContext db) : base(db)
        {
            manager = new ApplicationRoleManager(db);
           
        }
    }
}

﻿using DAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ApplicationUserIdentity : IdentityUser
    {
       // public string Id{ get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }


        public DateTime BirthDate { get; set; }

        public string Address { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        [Required]
        public bool isDeleted { get; set; }

        public virtual List<Payment> Payments { get; set; }
     
    }
    public class ApplicationUserStore : UserStore<ApplicationUserIdentity>
    {
        public ApplicationUserStore() : base(new ApplicationDBContext())
        {

        }
        public ApplicationUserStore(DbContext db) : base(db)
        {

        }
    }

    
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager()
            : base(new RoleStore<IdentityRole>(new ApplicationDBContext()))
        {

        }
        public ApplicationRoleManager(DbContext db)
            : base(new RoleStore<IdentityRole>(db))
        {

        }
    }
    public class ApplicationUserManager : UserManager<ApplicationUserIdentity>
    {
        public ApplicationUserManager() : base(new ApplicationUserStore())
        {

        }
        public ApplicationUserManager(DbContext db) : base(new ApplicationUserStore(db))
        {

        }
       
    }
  
 
   
    public class ApplicationDBContext : IdentityDbContext<ApplicationUserIdentity>
    {

        public ApplicationDBContext() :
            base("name=MVCEcommerece")
        {

        }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Wishlist> Wishlists { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }

        public virtual DbSet<ProductCart> ProductCarts { get; set; }
        public virtual DbSet<ProductWishList> ProductWishLists { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    }
}

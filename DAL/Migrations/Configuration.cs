namespace DAL.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.ApplicationDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.ApplicationDBContext context)
        {
            //ApplicationUserManager userManager = new ApplicationUserManager(context);

            //ApplicationUserIdentity admin = new ApplicationUserIdentity()
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Email = "test@gmail.com",
            //    FirstName = "Admin",
            //    LastName = "Admin",
            //    UserName = "Admin",
            //    PasswordHash = "Admin",
            //    BirthDate = DateTime.Now,
            //    isDeleted = false,
            //    EmailConfirmed = true,
            //    PhoneNumberConfirmed = true,
            //    TwoFactorEnabled = true,
            //    LockoutEnabled = true,
            //    AccessFailedCount = 0,
            //    SecurityStamp = Guid.NewGuid().ToString("D"),
            //    Gender = "Male",
            //    Address = "Admin",
            //};

            //admin.PasswordHash = userManager.PasswordHasher.HashPassword(admin.PasswordHash);

            //ApplicationUserIdentity user = new ApplicationUserIdentity()
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Email = "test@gmail.com",
            //    FirstName = "User",
            //    LastName = "User",
            //    UserName = "User",
            //    PasswordHash = "User",
            //    BirthDate = DateTime.Now,
            //    isDeleted = false,
            //    EmailConfirmed = true,
            //    PhoneNumberConfirmed = true,
            //    TwoFactorEnabled = true,
            //    LockoutEnabled = true,
            //    AccessFailedCount = 0,
            //    SecurityStamp = Guid.NewGuid().ToString("D"),
            //    Gender = "Male",
            //    Address = "Admin",
            //};

            //user.PasswordHash = userManager.PasswordHasher.HashPassword(user.PasswordHash);


            //userManager.Create(admin);
            //userManager.Create(user);

            //ApplicationRoleManager roleManager = new ApplicationRoleManager(context);
            //IdentityRole roleAdmin = new IdentityRole()
            //{
            //    Name = "Admin"
            //};
            //IdentityRole roleRegistered = new IdentityRole()
            //{
            //    Name = "RegisteredUser"
            //};

            //roleManager.Create(roleAdmin);
            //roleManager.Create(roleRegistered);

            //userManager.AddToRole(admin.Id, "Admin");
            //userManager.AddToRole(user.Id, "RegisteredUser");

            //context.Carts.Add(new Models.Cart
            //{
            //    ApplicationUserIdentity_Id = admin.Id
            //});
            //context.Carts.Add(new Models.Cart
            //{
            //    ApplicationUserIdentity_Id = user.Id
            //});

            //context.Wishlists.Add(new Models.Wishlist
            //{
            //    ApplicationUserIdentity_Id = admin.Id
            //});

            //context.Wishlists.Add(new Models.Wishlist
            //{
            //    ApplicationUserIdentity_Id = user.Id
            //});

            //// Add Categories 
            //Models.Category cat1 = new Models.Category { Name = "cat 1" };
            //Models.Category cat2 = new Models.Category { Name = "cat 2" };
            //Models.Category cat3 = new Models.Category { Name = "cat 3" };

            //context.Categories.Add(cat1);
            //context.Categories.Add(cat2);
            //context.Categories.Add(cat3);

            //// Register Products
            //context.Products.Add(new Models.Product
            //{
            //    Name = "Product 1",
            //    Description = "Product 1 Description",
            //    Discount = 5,
            //    Price = 500,
            //    Color = "Color 1",
            //    Quantity = 50,
            //    image = "best_1.png",
            //    CategoryId = 1
            //});

            //context.Products.Add(new Models.Product
            //{
            //    Name = "Product 2",
            //    Description = "Product 2 Description",
            //    Discount = 5,
            //    Price = 500,
            //    Color = "Color 2",
            //    Quantity = 50,
            //    image = "best_2.png",
            //    CategoryId = 2
            //});

            //context.Products.Add(new Models.Product
            //{
            //    Name = "Product 3",
            //    Description = "Product 3 Description",
            //    Discount = 5,
            //    Price = 500,
            //    Color = "Color 1",
            //    Quantity = 50,
            //    image = "best_3.png",
            //    CategoryId = 3
            //});


            //context.SaveChanges();
        }
    }
}

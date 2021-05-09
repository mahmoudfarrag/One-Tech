namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ApplicationUserIdentity_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserIdentity_Id)
                .Index(t => t.ApplicationUserIdentity_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        Country = c.String(),
                        Gender = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CardNumber = c.String(nullable: false, maxLength: 16),
                        ExperationDate = c.DateTime(nullable: false),
                        cardOwnerName = c.String(nullable: false),
                        cvc = c.String(nullable: false, maxLength: 3),
                        ApplicationUserIdentity_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserIdentity_Id)
                .Index(t => t.ApplicationUserIdentity_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ProductCarts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        productId = c.Int(nullable: false),
                        CartID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cart", t => t.CartID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.productId, cascadeDelete: true)
                .Index(t => t.productId)
                .Index(t => t.CartID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Description = c.String(nullable: false),
                        Color = c.String(),
                        Discount = c.Double(nullable: false),
                        image = c.String(),
                        Quantity = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        productTotal = c.Double(nullable: false),
                        productDiscount = c.Double(nullable: false),
                        ProductNetPrice = c.Double(nullable: false),
                        productQuantity = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        orderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Order", t => t.orderID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.orderID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        date = c.String(),
                        Description = c.String(),
                        totalPrice = c.Double(nullable: false),
                        ApplicationUserIdentity_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserIdentity_Id)
                .Index(t => t.ApplicationUserIdentity_Id);
            
            CreateTable(
                "dbo.ProductWishLists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        productId = c.Int(nullable: false),
                        WishlistID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.productId, cascadeDelete: true)
                .ForeignKey("dbo.Wishlist", t => t.WishlistID, cascadeDelete: true)
                .Index(t => t.productId)
                .Index(t => t.WishlistID);
            
            CreateTable(
                "dbo.Wishlist",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ApplicationUserIdentity_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserIdentity_Id)
                .Index(t => t.ApplicationUserIdentity_Id);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        rating = c.Int(nullable: false),
                        productID = c.Int(nullable: false),
                        userID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.productID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.userID)
                .Index(t => t.productID)
                .Index(t => t.userID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Review", "userID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Review", "productID", "dbo.Product");
            DropForeignKey("dbo.ProductCarts", "productId", "dbo.Product");
            DropForeignKey("dbo.ProductWishLists", "WishlistID", "dbo.Wishlist");
            DropForeignKey("dbo.Wishlist", "ApplicationUserIdentity_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductWishLists", "productId", "dbo.Product");
            DropForeignKey("dbo.OrderProducts", "ProductID", "dbo.Product");
            DropForeignKey("dbo.OrderProducts", "orderID", "dbo.Order");
            DropForeignKey("dbo.Order", "ApplicationUserIdentity_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.ProductCarts", "CartID", "dbo.Cart");
            DropForeignKey("dbo.Cart", "ApplicationUserIdentity_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Payment", "ApplicationUserIdentity_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Review", new[] { "userID" });
            DropIndex("dbo.Review", new[] { "productID" });
            DropIndex("dbo.Wishlist", new[] { "ApplicationUserIdentity_Id" });
            DropIndex("dbo.ProductWishLists", new[] { "WishlistID" });
            DropIndex("dbo.ProductWishLists", new[] { "productId" });
            DropIndex("dbo.Order", new[] { "ApplicationUserIdentity_Id" });
            DropIndex("dbo.OrderProducts", new[] { "orderID" });
            DropIndex("dbo.OrderProducts", new[] { "ProductID" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropIndex("dbo.ProductCarts", new[] { "CartID" });
            DropIndex("dbo.ProductCarts", new[] { "productId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Payment", new[] { "ApplicationUserIdentity_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Cart", new[] { "ApplicationUserIdentity_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Review");
            DropTable("dbo.Wishlist");
            DropTable("dbo.ProductWishLists");
            DropTable("dbo.Order");
            DropTable("dbo.OrderProducts");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.ProductCarts");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Payment");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Cart");
        }
    }
}

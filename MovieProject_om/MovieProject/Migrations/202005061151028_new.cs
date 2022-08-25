namespace MovieProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 255),
                        BillingAddress = c.String(nullable: false),
                        BillingZip = c.String(nullable: false),
                        BillingCity = c.String(nullable: false),
                        DeliveryAddress = c.String(nullable: false),
                        DeliveryZip = c.String(nullable: false),
                        DeliveryCity = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderRows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Movie_Id = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Movie_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Director = c.String(nullable: false),
                        ReleaseYear = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderRows", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderRows", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.OrderRows", new[] { "Order_Id" });
            DropIndex("dbo.OrderRows", new[] { "Movie_Id" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropTable("dbo.Movies");
            DropTable("dbo.OrderRows");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}

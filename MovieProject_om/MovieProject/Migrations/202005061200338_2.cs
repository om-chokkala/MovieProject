namespace MovieProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.OrderRows", name: "Order_Id", newName: "OrderId");
            RenameColumn(table: "dbo.OrderRows", name: "Movie_Id", newName: "MovieId");
            RenameIndex(table: "dbo.OrderRows", name: "IX_Movie_Id", newName: "IX_MovieId");
            RenameIndex(table: "dbo.OrderRows", name: "IX_Order_Id", newName: "IX_OrderId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.OrderRows", name: "IX_OrderId", newName: "IX_Order_Id");
            RenameIndex(table: "dbo.OrderRows", name: "IX_MovieId", newName: "IX_Movie_Id");
            RenameColumn(table: "dbo.OrderRows", name: "MovieId", newName: "Movie_Id");
            RenameColumn(table: "dbo.OrderRows", name: "OrderId", newName: "Order_Id");
        }
    }
}

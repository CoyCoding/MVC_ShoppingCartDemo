namespace ShoppingCartDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagesconnection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Image_Id", "dbo.Images");
            DropIndex("dbo.Products", new[] { "Image_Id" });
            RenameColumn(table: "dbo.Products", name: "Image_Id", newName: "ImageId");
            AlterColumn("dbo.Products", "ImageId", c => c.Int(nullable: true));
            CreateIndex("dbo.Products", "ImageId");
            AddForeignKey("dbo.Products", "ImageId", "dbo.Images", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ImageId", "dbo.Images");
            DropIndex("dbo.Products", new[] { "ImageId" });
            AlterColumn("dbo.Products", "ImageId", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "ImageId", newName: "Image_Id");
            CreateIndex("dbo.Products", "Image_Id");
            AddForeignKey("dbo.Products", "Image_Id", "dbo.Images", "Id");
        }
    }
}

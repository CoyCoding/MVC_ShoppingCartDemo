namespace ShoppingCartDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productImageUpdates : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "ImageId", "dbo.Images");
            DropIndex("dbo.Products", new[] { "ImageId" });
            AddColumn("dbo.Images", "ImageName", c => c.String(maxLength: 255));
            AddColumn("dbo.Images", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Images", "ProductId");
            AddForeignKey("dbo.Images", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            DropColumn("dbo.Products", "ImageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ImageId", c => c.Int());
            DropForeignKey("dbo.Images", "ProductId", "dbo.Products");
            DropIndex("dbo.Images", new[] { "ProductId" });
            DropColumn("dbo.Images", "ProductId");
            DropColumn("dbo.Images", "ImageName");
            CreateIndex("dbo.Products", "ImageId");
            AddForeignKey("dbo.Products", "ImageId", "dbo.Images", "Id");
        }
    }
}

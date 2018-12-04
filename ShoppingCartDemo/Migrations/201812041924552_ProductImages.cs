namespace ShoppingCartDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductImages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                        ImageDescription = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductImages", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductImages", new[] { "ProductId" });
            DropTable("dbo.ProductImages");
        }
    }
}

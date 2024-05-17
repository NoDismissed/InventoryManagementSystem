namespace InventoryManagementSystem.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        Item_ID = c.Int(nullable: false, identity: true),
                        Item_Name = c.String(nullable: false),
                        Item_Description = c.String(nullable: false),
                        Item_Amount = c.Int(nullable: false),
                        Item_InputDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Item_ID);
            
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        Purchase_ID = c.Int(nullable: false, identity: true),
                        Purchase_Amount = c.Int(nullable: false),
                        Purchase_Date = c.DateTime(nullable: false),
                        item_Item_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Purchase_ID)
                .ForeignKey("dbo.Item", t => t.item_Item_ID)
                .Index(t => t.item_Item_ID);
            
            CreateTable(
                "dbo.Sale",
                c => new
                    {
                        Sale_ID = c.Int(nullable: false, identity: true),
                        Sale_Amount = c.Int(nullable: false),
                        Sale_Date = c.DateTime(nullable: false),
                        item_Item_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Sale_ID)
                .ForeignKey("dbo.Item", t => t.item_Item_ID)
                .Index(t => t.item_Item_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sale", "item_Item_ID", "dbo.Item");
            DropForeignKey("dbo.Purchase", "item_Item_ID", "dbo.Item");
            DropIndex("dbo.Sale", new[] { "item_Item_ID" });
            DropIndex("dbo.Purchase", new[] { "item_Item_ID" });
            DropTable("dbo.Sale");
            DropTable("dbo.Purchase");
            DropTable("dbo.Item");
        }
    }
}

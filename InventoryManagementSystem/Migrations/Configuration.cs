namespace InventoryManagementSystem.Migrations
{
    using InventoryManagementSystem.Models;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context.DatabaseContext context)
        {
            context.Items.AddOrUpdate(x => x.Item_ID,
                new Item() { Item_Name = "USB Cable", Item_Description = "USB-A. USB-A", Item_Amount = 10, Item_InputDate = DateTime.Now },
                new Item() { Item_Name = "Keyboard", Item_Description = "Qwerty Keyboards designed in old fashioned typewriters", Item_Amount = 15, Item_InputDate = DateTime.Now },
                new Item() { Item_Name = "Mouse", Item_Description = "Laser Mouse", Item_Amount = 20, Item_InputDate = DateTime.Now }
            );
        }
    }
}

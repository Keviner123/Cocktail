namespace Bartender.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ingredients",
                c => new
                    {
                        IngredientName = c.String(nullable: false, maxLength: 128),
                        Drink_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IngredientName)
                .ForeignKey("dbo.drinks", t => t.Drink_Name)
                .Index(t => t.Drink_Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ingredients", "Drink_Name", "dbo.drinks");
            DropIndex("dbo.ingredients", new[] { "Drink_Name" });
            DropTable("dbo.ingredients");
        }
    }
}

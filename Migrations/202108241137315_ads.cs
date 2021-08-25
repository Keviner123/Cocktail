namespace Bartender.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ads : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ingredients", "Drink_Name", "dbo.drinks");
            DropIndex("dbo.ingredients", new[] { "Drink_Name" });
            CreateTable(
                "dbo.IngredientDrinks",
                c => new
                    {
                        Ingredient_IngredientName = c.String(nullable: false, maxLength: 128),
                        Drink_Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Ingredient_IngredientName, t.Drink_Name })
                .ForeignKey("dbo.ingredients", t => t.Ingredient_IngredientName, cascadeDelete: true)
                .ForeignKey("dbo.drinks", t => t.Drink_Name, cascadeDelete: true)
                .Index(t => t.Ingredient_IngredientName)
                .Index(t => t.Drink_Name);
            
            DropColumn("dbo.ingredients", "Drink_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ingredients", "Drink_Name", c => c.String(maxLength: 128));
            DropForeignKey("dbo.IngredientDrinks", "Drink_Name", "dbo.drinks");
            DropForeignKey("dbo.IngredientDrinks", "Ingredient_IngredientName", "dbo.ingredients");
            DropIndex("dbo.IngredientDrinks", new[] { "Drink_Name" });
            DropIndex("dbo.IngredientDrinks", new[] { "Ingredient_IngredientName" });
            DropTable("dbo.IngredientDrinks");
            CreateIndex("dbo.ingredients", "Drink_Name");
            AddForeignKey("dbo.ingredients", "Drink_Name", "dbo.drinks", "Name");
        }
    }
}

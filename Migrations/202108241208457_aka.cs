namespace Bartender.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aka : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IngredientDrinks", "Ingredient_IngredientName", "dbo.ingredients");
            DropIndex("dbo.IngredientDrinks", new[] { "Ingredient_IngredientName" });
            RenameColumn(table: "dbo.IngredientDrinks", name: "Ingredient_IngredientName", newName: "Ingredient_IngredientId");
            DropPrimaryKey("dbo.ingredients");
            DropPrimaryKey("dbo.IngredientDrinks");
            AddColumn("dbo.ingredients", "IngredientId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ingredients", "Liquid_Name", c => c.String(maxLength: 128));
            AlterColumn("dbo.IngredientDrinks", "Ingredient_IngredientId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ingredients", "IngredientId");
            AddPrimaryKey("dbo.IngredientDrinks", new[] { "Ingredient_IngredientId", "Drink_Name" });
            CreateIndex("dbo.ingredients", "Liquid_Name");
            CreateIndex("dbo.IngredientDrinks", "Ingredient_IngredientId");
            AddForeignKey("dbo.ingredients", "Liquid_Name", "dbo.liquids", "Name");
            AddForeignKey("dbo.IngredientDrinks", "Ingredient_IngredientId", "dbo.ingredients", "IngredientId", cascadeDelete: true);
            DropColumn("dbo.ingredients", "IngredientName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ingredients", "IngredientName", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.IngredientDrinks", "Ingredient_IngredientId", "dbo.ingredients");
            DropForeignKey("dbo.ingredients", "Liquid_Name", "dbo.liquids");
            DropIndex("dbo.IngredientDrinks", new[] { "Ingredient_IngredientId" });
            DropIndex("dbo.ingredients", new[] { "Liquid_Name" });
            DropPrimaryKey("dbo.IngredientDrinks");
            DropPrimaryKey("dbo.ingredients");
            AlterColumn("dbo.IngredientDrinks", "Ingredient_IngredientId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.ingredients", "Liquid_Name");
            DropColumn("dbo.ingredients", "IngredientId");
            AddPrimaryKey("dbo.IngredientDrinks", new[] { "Ingredient_IngredientName", "Drink_Name" });
            AddPrimaryKey("dbo.ingredients", "IngredientName");
            RenameColumn(table: "dbo.IngredientDrinks", name: "Ingredient_IngredientId", newName: "Ingredient_IngredientName");
            CreateIndex("dbo.IngredientDrinks", "Ingredient_IngredientName");
            AddForeignKey("dbo.IngredientDrinks", "Ingredient_IngredientName", "dbo.ingredients", "IngredientName", cascadeDelete: true);
        }
    }
}

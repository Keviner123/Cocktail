namespace Bartender.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaaaaa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.liquids",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        AlcoholPercentage = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.liquids");
        }
    }
}

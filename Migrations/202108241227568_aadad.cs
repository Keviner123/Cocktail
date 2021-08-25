namespace Bartender.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aadad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ingredients", "VolumeML", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ingredients", "VolumeML");
        }
    }
}

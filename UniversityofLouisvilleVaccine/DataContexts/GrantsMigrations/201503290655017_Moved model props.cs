namespace UniversityofLouisvilleVaccine.DataContexts.GrantsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Movedmodelprops : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Grants", "grantTitle");
            DropColumn("dbo.Grants", "grantStart");
            DropColumn("dbo.Grants", "grantEnd");
            DropColumn("dbo.Grants", "grantAmount");
            DropColumn("dbo.Grants", "grantFunder");
            DropColumn("dbo.Grants", "collaboratorID");
            DropColumn("dbo.Grants", "coordID");
            DropColumn("dbo.Grants", "coordName");
            DropColumn("dbo.Grants", "deadline");
            DropColumn("dbo.Grants", "maxPages");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Grants", "maxPages", c => c.Int(nullable: false));
            AddColumn("dbo.Grants", "deadline", c => c.DateTime(nullable: false));
            AddColumn("dbo.Grants", "coordName", c => c.String());
            AddColumn("dbo.Grants", "coordID", c => c.String());
            AddColumn("dbo.Grants", "collaboratorID", c => c.String());
            AddColumn("dbo.Grants", "grantFunder", c => c.String());
            AddColumn("dbo.Grants", "grantAmount", c => c.Int(nullable: false));
            AddColumn("dbo.Grants", "grantEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Grants", "grantStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Grants", "grantTitle", c => c.String());
        }
    }
}

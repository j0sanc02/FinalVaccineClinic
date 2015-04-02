namespace UniversityofLouisvilleVaccine.DataContexts.GrantsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Formats : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Grants", "fileName", c => c.String(nullable: false));
            AlterColumn("dbo.Grants", "docType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Grants", "docType", c => c.String());
            AlterColumn("dbo.Grants", "fileName", c => c.String());
        }
    }
}

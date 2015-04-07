namespace UniversityofLouisvilleVaccine.DataContexts.GrantsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _return : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grants", "fileName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Grants", "fileName");
        }
    }
}

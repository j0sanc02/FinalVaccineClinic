namespace UniversityofLouisvilleVaccine.DataContexts.GrantsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setfilename : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Grants", "fileName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Grants", "fileName", c => c.String(nullable: false));
        }
    }
}

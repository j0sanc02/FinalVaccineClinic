namespace UniversityofLouisvilleVaccine.DataContexts.GrantsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedtitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grants", "filetitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Grants", "filetitle");
        }
    }
}

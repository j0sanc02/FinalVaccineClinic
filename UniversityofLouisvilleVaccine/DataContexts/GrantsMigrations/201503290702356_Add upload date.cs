namespace UniversityofLouisvilleVaccine.DataContexts.GrantsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adduploaddate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grants", "uploadDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Grants", "uploadDate");
        }
    }
}

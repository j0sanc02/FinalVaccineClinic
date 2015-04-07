namespace UniversityofLouisvilleVaccine.DataContexts.GrantsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changefilenamenullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Grants", "fileName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Grants", "fileName", c => c.String(nullable: false));
        }
    }
}

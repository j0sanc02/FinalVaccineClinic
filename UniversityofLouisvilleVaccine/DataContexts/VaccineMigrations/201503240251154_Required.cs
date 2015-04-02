namespace UniversityofLouisvilleVaccine.DataContexts.VaccineMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vaccines", "vaccineID", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vaccines", "vaccineID", c => c.String());
        }
    }
}

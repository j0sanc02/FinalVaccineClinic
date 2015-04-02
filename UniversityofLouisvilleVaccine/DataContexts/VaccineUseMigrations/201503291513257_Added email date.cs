namespace UniversityofLouisvilleVaccine.DataContexts.VaccineUseMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedemaildate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VaccineUses", "emaildate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VaccineUses", "emaildate");
        }
    }
}

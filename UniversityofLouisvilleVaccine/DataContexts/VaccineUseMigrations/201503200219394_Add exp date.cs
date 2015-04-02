namespace UniversityofLouisvilleVaccine.DataContexts.VaccineUseMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addexpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VaccineUses", "expdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VaccineUses", "expdate");
        }
    }
}

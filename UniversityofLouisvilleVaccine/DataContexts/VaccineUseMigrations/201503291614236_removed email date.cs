namespace UniversityofLouisvilleVaccine.DataContexts.VaccineUseMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedemaildate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.VaccineUses", "emaildate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VaccineUses", "emaildate", c => c.DateTime(nullable: false));
        }
    }
}

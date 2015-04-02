namespace UniversityofLouisvilleVaccine.DataContexts.VaccineUseMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedinjectionsites : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VaccineUses", "LIntradermal", c => c.Boolean(nullable: false));
            AddColumn("dbo.VaccineUses", "RIntradermal", c => c.Boolean(nullable: false));
            AddColumn("dbo.VaccineUses", "LIntramuscular", c => c.Boolean(nullable: false));
            AddColumn("dbo.VaccineUses", "RIntramuscular", c => c.Boolean(nullable: false));
            AddColumn("dbo.VaccineUses", "lsub", c => c.Boolean(nullable: false));
            AddColumn("dbo.VaccineUses", "rsub", c => c.Boolean(nullable: false));
            AddColumn("dbo.VaccineUses", "lnasal", c => c.Boolean(nullable: false));
            AddColumn("dbo.VaccineUses", "rnasal", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VaccineUses", "rnasal");
            DropColumn("dbo.VaccineUses", "lnasal");
            DropColumn("dbo.VaccineUses", "rsub");
            DropColumn("dbo.VaccineUses", "lsub");
            DropColumn("dbo.VaccineUses", "RIntramuscular");
            DropColumn("dbo.VaccineUses", "LIntramuscular");
            DropColumn("dbo.VaccineUses", "RIntradermal");
            DropColumn("dbo.VaccineUses", "LIntradermal");
        }
    }
}

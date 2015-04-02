namespace UniversityofLouisvilleVaccine.DataContexts.VaccineUseMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VaccineUses",
                c => new
                    {
                        VaccineUseId = c.Int(nullable: false, identity: true),
                        vaccineID = c.String(nullable: false),
                        lotNumber = c.String(nullable: false),
                        patientID = c.String(nullable: false),
                        LinjectionSite = c.Boolean(nullable: false),
                        RinjectionSite = c.Boolean(nullable: false),
                        quantity = c.Int(nullable: false),
                        VaccineUseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VaccineUseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VaccineUses");
        }
    }
}

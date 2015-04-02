namespace UniversityofLouisvilleVaccine.DataContexts.VaccineMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vaccines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        vaccineID = c.String(nullable: false),
                        vaccineName = c.String(nullable: false),
                        dateReceived = c.DateTime(nullable: false),
                        CPT = c.String(nullable: false),
                        ICD9Code = c.String(nullable: false),
                        NDC = c.String(nullable: false),
                        leadTime = c.Int(nullable: false),
                        lotNumber = c.String(nullable: false),
                        numofDoses = c.Int(nullable: false),
                        salesPrice = c.Int(nullable: false),
                        expDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vaccines");
        }
    }
}

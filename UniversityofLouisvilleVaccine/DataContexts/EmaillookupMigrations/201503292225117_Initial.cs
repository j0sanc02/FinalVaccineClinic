namespace UniversityofLouisvilleVaccine.DataContexts.EmaillookupMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailLookups",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        VacID = c.String(),
                        VacName = c.String(),
                        lotn = c.Int(nullable: false),
                        sent = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            DropTable("dbo.EmailLoookups");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EmailLoookups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VaccineID = c.String(),
                        dateSent = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.EmailLookups");
        }
    }
}

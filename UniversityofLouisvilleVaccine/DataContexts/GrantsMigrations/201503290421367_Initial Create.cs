namespace UniversityofLouisvilleVaccine.DataContexts.GrantsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grants",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        docType = c.String(),
                        fileName = c.String(),
                        grantTitle = c.String(),
                        grantStart = c.DateTime(nullable: false),
                        grantEnd = c.DateTime(nullable: false),
                        grantAmount = c.Int(nullable: false),
                        grantFunder = c.String(),
                        collaboratorID = c.String(),
                        coordID = c.String(),
                        coordName = c.String(),
                        deadline = c.DateTime(nullable: false),
                        maxPages = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Grants");
        }
    }
}

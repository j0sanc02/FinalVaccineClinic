namespace UniversityofLouisvilleVaccine.DataContexts.VendorMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        vendorID = c.String(nullable: false, maxLength: 128),
                        vendorName = c.String(nullable: false),
                        vendorPhone = c.String(nullable: false),
                        vendorFax = c.String(nullable: false),
                        vendorEmail = c.String(nullable: false),
                        vendorWebsite = c.String(nullable: false),
                        vendorAddress = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.vendorID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vendors");
        }
    }
}

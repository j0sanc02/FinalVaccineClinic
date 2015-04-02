namespace UniversityofLouisvilleVaccine.DataContexts.VendorMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removedduplicateid : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vendors", "vendorID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vendors", "vendorID", c => c.String());
        }
    }
}

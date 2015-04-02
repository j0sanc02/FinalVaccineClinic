namespace UniversityofLouisvilleVaccine.DataContexts.VendorMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addfields : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Vendors");
            AddColumn("dbo.Vendors", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Vendors", "vendorAddress1", c => c.String());
            AddColumn("dbo.Vendors", "vendorAddress2", c => c.String());
            AddColumn("dbo.Vendors", "city", c => c.String());
            AddColumn("dbo.Vendors", "state", c => c.String());
            AddColumn("dbo.Vendors", "zip", c => c.String());
            AddColumn("dbo.Vendors", "vaccines", c => c.String());
            AlterColumn("dbo.Vendors", "vendorID", c => c.String());
            AlterColumn("dbo.Vendors", "vendorName", c => c.String());
            AlterColumn("dbo.Vendors", "vendorPhone", c => c.String());
            AlterColumn("dbo.Vendors", "vendorFax", c => c.String());
            AlterColumn("dbo.Vendors", "vendorEmail", c => c.String());
            AlterColumn("dbo.Vendors", "vendorWebsite", c => c.String());
            AddPrimaryKey("dbo.Vendors", "ID");
            DropColumn("dbo.Vendors", "vendorAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vendors", "vendorAddress", c => c.String(nullable: false));
            DropPrimaryKey("dbo.Vendors");
            AlterColumn("dbo.Vendors", "vendorWebsite", c => c.String(nullable: false));
            AlterColumn("dbo.Vendors", "vendorEmail", c => c.String(nullable: false));
            AlterColumn("dbo.Vendors", "vendorFax", c => c.String(nullable: false));
            AlterColumn("dbo.Vendors", "vendorPhone", c => c.String(nullable: false));
            AlterColumn("dbo.Vendors", "vendorName", c => c.String(nullable: false));
            AlterColumn("dbo.Vendors", "vendorID", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Vendors", "vaccines");
            DropColumn("dbo.Vendors", "zip");
            DropColumn("dbo.Vendors", "state");
            DropColumn("dbo.Vendors", "city");
            DropColumn("dbo.Vendors", "vendorAddress2");
            DropColumn("dbo.Vendors", "vendorAddress1");
            DropColumn("dbo.Vendors", "ID");
            AddPrimaryKey("dbo.Vendors", "vendorID");
        }
    }
}

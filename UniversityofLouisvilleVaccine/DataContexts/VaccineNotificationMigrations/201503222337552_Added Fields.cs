namespace UniversityofLouisvilleVaccine.DataContexts.VaccineNotificationMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VaccineNotifications", "warning", c => c.Int(nullable: false));
            AlterColumn("dbo.VaccineNotifications", "numofDoses", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VaccineNotifications", "numofDoses", c => c.String());
            DropColumn("dbo.VaccineNotifications", "warning");
        }
    }
}

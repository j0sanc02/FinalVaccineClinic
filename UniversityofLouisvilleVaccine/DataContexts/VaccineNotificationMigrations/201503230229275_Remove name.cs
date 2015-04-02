namespace UniversityofLouisvilleVaccine.DataContexts.VaccineNotificationMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removename : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.VaccineNotifications", "expDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VaccineNotifications", "expDate", c => c.DateTime(nullable: false));
        }
    }
}

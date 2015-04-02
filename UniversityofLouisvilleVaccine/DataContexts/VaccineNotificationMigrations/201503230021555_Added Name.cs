namespace UniversityofLouisvilleVaccine.DataContexts.VaccineNotificationMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VaccineNotifications", "vaccineName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VaccineNotifications", "vaccineName");
        }
    }
}

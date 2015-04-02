namespace UniversityofLouisvilleVaccine.DataContexts.VaccineNotificationMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VaccineNotifications",
                c => new
                    {
                        NotificationID = c.Int(nullable: false, identity: true),
                        vaccineID = c.String(),
                        lotNumber = c.String(),
                        numofDoses = c.String(),
                        expDate = c.DateTime(nullable: false),
                        notificationchecked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.NotificationID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VaccineNotifications");
        }
    }
}

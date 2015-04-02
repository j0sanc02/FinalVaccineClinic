namespace UniversityofLouisvilleVaccine.DataContexts.ApptMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        start = c.String(),
                        hour = c.Double(nullable: false),
                        min = c.Double(nullable: false),
                        end = c.String(),
                        allDay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Appointments");
        }
    }
}

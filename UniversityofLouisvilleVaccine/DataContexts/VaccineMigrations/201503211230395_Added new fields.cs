namespace UniversityofLouisvilleVaccine.DataContexts.VaccineMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addednewfields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vaccines", "refugeePrice", c => c.Int(nullable: false));
            AddColumn("dbo.Vaccines", "clinicPrice", c => c.Int(nullable: false));
            AddColumn("dbo.Vaccines", "description", c => c.String(nullable: false));
            AddColumn("dbo.Vaccines", "inventoryWarning", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vaccines", "inventoryWarning");
            DropColumn("dbo.Vaccines", "description");
            DropColumn("dbo.Vaccines", "clinicPrice");
            DropColumn("dbo.Vaccines", "refugeePrice");
        }
    }
}

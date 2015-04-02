namespace UniversityofLouisvilleVaccine.DataContexts.EmaillookupMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedinttostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmailLookups", "lotn", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmailLookups", "lotn", c => c.Int(nullable: false));
        }
    }
}

namespace UniversityofLouisvilleVaccine.DataContexts.GrantsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfiletype : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FilePaths",
                c => new
                    {
                        FilePathId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        FileType = c.Int(nullable: false),
                        GrantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilePathId)
                .ForeignKey("dbo.Grants", t => t.GrantID, cascadeDelete: true)
                .Index(t => t.GrantID);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        GrantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Grants", t => t.GrantID, cascadeDelete: true)
                .Index(t => t.GrantID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "GrantID", "dbo.Grants");
            DropForeignKey("dbo.FilePaths", "GrantID", "dbo.Grants");
            DropIndex("dbo.Files", new[] { "GrantID" });
            DropIndex("dbo.FilePaths", new[] { "GrantID" });
            DropTable("dbo.Files");
            DropTable("dbo.FilePaths");
        }
    }
}

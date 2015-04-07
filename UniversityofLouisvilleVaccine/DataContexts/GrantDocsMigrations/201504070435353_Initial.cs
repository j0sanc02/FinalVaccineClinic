namespace UniversityofLouisvilleVaccine.DataContexts.GrantDocsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DocFilePaths",
                c => new
                    {
                        FilePathId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        FileType = c.Int(nullable: false),
                        GrantDocID = c.Int(nullable: false),
                        Grant_id = c.Int(),
                    })
                .PrimaryKey(t => t.FilePathId)
                .ForeignKey("dbo.GrantDocs", t => t.Grant_id)
                .Index(t => t.Grant_id);
            
            CreateTable(
                "dbo.GrantDocs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fileName = c.String(nullable: false),
                        docType = c.String(nullable: false),
                        uploadDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.DocFiles",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        GrantDocID = c.Int(nullable: false),
                        Grant_id = c.Int(),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.GrantDocs", t => t.Grant_id)
                .Index(t => t.Grant_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DocFiles", "Grant_id", "dbo.GrantDocs");
            DropForeignKey("dbo.DocFilePaths", "Grant_id", "dbo.GrantDocs");
            DropIndex("dbo.DocFiles", new[] { "Grant_id" });
            DropIndex("dbo.DocFilePaths", new[] { "Grant_id" });
            DropTable("dbo.DocFiles");
            DropTable("dbo.GrantDocs");
            DropTable("dbo.DocFilePaths");
        }
    }
}

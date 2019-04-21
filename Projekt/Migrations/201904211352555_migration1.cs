namespace Projekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        EndDate = c.DateTime(nullable: false),
                        IsDone = c.Boolean(nullable: false),
                        Priority = c.Int(nullable: false),
                        category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.category_Id)
                .Index(t => t.category_Id);
            
            CreateTable(
                "dbo.Steps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDone = c.Boolean(nullable: false),
                        Description = c.String(nullable: false),
                        task_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.task_Id)
                .Index(t => t.task_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Steps", "task_Id", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "category_Id", "dbo.Categories");
            DropIndex("dbo.Steps", new[] { "task_Id" });
            DropIndex("dbo.Tasks", new[] { "category_Id" });
            DropTable("dbo.Steps");
            DropTable("dbo.Tasks");
            DropTable("dbo.Categories");
        }
    }
}

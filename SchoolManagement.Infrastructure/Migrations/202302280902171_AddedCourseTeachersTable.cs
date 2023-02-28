namespace SchoolManagement.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCourseTeachersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseTeachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseTeachers", "TeacherId", "dbo.Users");
            DropIndex("dbo.CourseTeachers", new[] { "TeacherId" });
            DropTable("dbo.CourseTeachers");
        }
    }
}

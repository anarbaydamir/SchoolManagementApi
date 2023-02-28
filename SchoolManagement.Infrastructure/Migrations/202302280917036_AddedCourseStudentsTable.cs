namespace SchoolManagement.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCourseStudentsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseTeacherId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseTeachers", t => t.CourseTeacherId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.CourseTeacherId)
                .Index(t => t.StudentId);
            
            CreateIndex("dbo.CourseTeachers", "CourseId");
            AddForeignKey("dbo.CourseTeachers", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseStudents", "StudentId", "dbo.Users");
            DropForeignKey("dbo.CourseStudents", "CourseTeacherId", "dbo.CourseTeachers");
            DropForeignKey("dbo.CourseTeachers", "CourseId", "dbo.Courses");
            DropIndex("dbo.CourseStudents", new[] { "StudentId" });
            DropIndex("dbo.CourseStudents", new[] { "CourseTeacherId" });
            DropIndex("dbo.CourseTeachers", new[] { "CourseId" });
            DropTable("dbo.CourseStudents");
        }
    }
}

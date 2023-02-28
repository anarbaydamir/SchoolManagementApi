namespace SchoolManagement.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignmentAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Answer = c.String(unicode: false),
                        Grade = c.Double(nullable: false),
                        StudentId = c.Int(nullable: false),
                        AssignmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assignments", t => t.AssignmentId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.AssignmentId);
            
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Question = c.String(unicode: false),
                        CorrectAnswer = c.String(unicode: false),
                        CourseTeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseTeachers", t => t.CourseTeacherId, cascadeDelete: true)
                .Index(t => t.CourseTeacherId);
            
            AddColumn("dbo.CourseTeachers", "CourseTeacher_Id", c => c.Int());
            CreateIndex("dbo.CourseTeachers", "CourseTeacher_Id");
            AddForeignKey("dbo.CourseTeachers", "CourseTeacher_Id", "dbo.CourseTeachers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseTeachers", "CourseTeacher_Id", "dbo.CourseTeachers");
            DropForeignKey("dbo.AssignmentAnswers", "StudentId", "dbo.Users");
            DropForeignKey("dbo.Assignments", "CourseTeacherId", "dbo.CourseTeachers");
            DropForeignKey("dbo.AssignmentAnswers", "AssignmentId", "dbo.Assignments");
            DropIndex("dbo.Assignments", new[] { "CourseTeacherId" });
            DropIndex("dbo.AssignmentAnswers", new[] { "AssignmentId" });
            DropIndex("dbo.AssignmentAnswers", new[] { "StudentId" });
            DropIndex("dbo.CourseTeachers", new[] { "CourseTeacher_Id" });
            DropColumn("dbo.CourseTeachers", "CourseTeacher_Id");
            DropTable("dbo.Assignments");
            DropTable("dbo.AssignmentAnswers");
        }
    }
}

namespace Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Credits = c.Int(nullable: false),
                        CreateBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                        Department_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.Department_ID)
                .Index(t => t.Department_ID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Budget = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        RowVersion = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        Instructor_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Instructors", t => t.Instructor_ID)
                .Index(t => t.Instructor_ID);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.People", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        Email = c.String(),
                        Phone = c.Int(nullable: false),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        UnitOrApartmentNumber = c.Int(nullable: false),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                        Instructor = c.String(),
                        Password = c.String(),
                        Salt = c.String(),
                        IsLocked = c.Boolean(nullable: false),
                        LastLockedDateTime = c.DateTime(nullable: false),
                        FailedAttempts = c.Int(nullable: false),
                        DateofBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdateDate = c.DateTime(nullable: false),
                        UpdateBy = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Grade = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        Student_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.Student_ID)
                .Index(t => t.Student_ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        EnrollmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.People", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.OfficeAssignments",
                c => new
                    {
                        InstructorID = c.Int(nullable: false),
                        Location = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.InstructorID)
                .ForeignKey("dbo.Instructors", t => t.InstructorID)
                .Index(t => t.InstructorID);
            
            CreateTable(
                "dbo.RolePersons",
                c => new
                    {
                        Role_ID = c.Int(nullable: false),
                        Person_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_ID, t.Person_ID })
                .ForeignKey("dbo.Roles", t => t.Role_ID, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Person_ID, cascadeDelete: true)
                .Index(t => t.Role_ID)
                .Index(t => t.Person_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OfficeAssignments", "InstructorID", "dbo.Instructors");
            DropForeignKey("dbo.Enrollments", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.Students", "ID", "dbo.People");
            DropForeignKey("dbo.Courses", "Department_ID", "dbo.Departments");
            DropForeignKey("dbo.Departments", "Instructor_ID", "dbo.Instructors");
            DropForeignKey("dbo.Instructors", "ID", "dbo.People");
            DropForeignKey("dbo.RolePersons", "Person_ID", "dbo.People");
            DropForeignKey("dbo.RolePersons", "Role_ID", "dbo.Roles");
            DropIndex("dbo.RolePersons", new[] { "Person_ID" });
            DropIndex("dbo.RolePersons", new[] { "Role_ID" });
            DropIndex("dbo.OfficeAssignments", new[] { "InstructorID" });
            DropIndex("dbo.Students", new[] { "ID" });
            DropIndex("dbo.Enrollments", new[] { "Student_ID" });
            DropIndex("dbo.Instructors", new[] { "ID" });
            DropIndex("dbo.Departments", new[] { "Instructor_ID" });
            DropIndex("dbo.Courses", new[] { "Department_ID" });
            DropTable("dbo.RolePersons");
            DropTable("dbo.OfficeAssignments");
            DropTable("dbo.Students");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Roles");
            DropTable("dbo.People");
            DropTable("dbo.Instructors");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
        }
    }
}

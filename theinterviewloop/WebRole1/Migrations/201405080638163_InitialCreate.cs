namespace WebRole1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidate",
                c => new
                    {
                        CandidateId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.CandidateId);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Interviewer",
                c => new
                    {
                        InterviewerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CompanyId = c.Int(nullable: false),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.InterviewerId)
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.InterviewLoop",
                c => new
                    {
                        InterviewLoopId = c.Int(nullable: false, identity: true),
                        CandidateId = c.Int(nullable: false),
                        Location = c.String(),
                        StartDate = c.String(),
                        EndDate = c.String(),
                        ScheduledBy = c.String(),
                        Rating = c.Int(nullable: false),
                        Notes = c.String(),
                        CompanyId = c.Int(nullable: false),
                        Interviewer_InterviewerId = c.Int(),
                    })
                .PrimaryKey(t => t.InterviewLoopId)
                .ForeignKey("dbo.Candidate", t => t.CandidateId, cascadeDelete: true)
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Interviewer", t => t.Interviewer_InterviewerId)
                .Index(t => t.CandidateId)
                .Index(t => t.CompanyId)
                .Index(t => t.Interviewer_InterviewerId);
            
            CreateTable(
                "dbo.Interview",
                c => new
                    {
                        InterviewId = c.Int(nullable: false, identity: true),
                        InterviewerId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                        Location = c.String(),
                        Rating = c.Int(nullable: false),
                        Notes = c.String(),
                        QuestionAnswer_QuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.InterviewId)
                .ForeignKey("dbo.Interviewer", t => t.InterviewerId, cascadeDelete: true)
                .ForeignKey("dbo.QuestionAnswer", t => t.QuestionAnswer_QuestionId)
                .Index(t => t.InterviewerId)
                .Index(t => t.QuestionAnswer_QuestionId);
            
            CreateTable(
                "dbo.QuestionAnswer",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Notes = c.String(),
                        Duration = c.DateTime(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Interview", "QuestionAnswer_QuestionId", "dbo.QuestionAnswer");
            DropForeignKey("dbo.Interview", "InterviewerId", "dbo.Interviewer");
            DropForeignKey("dbo.InterviewLoop", "Interviewer_InterviewerId", "dbo.Interviewer");
            DropForeignKey("dbo.InterviewLoop", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.InterviewLoop", "CandidateId", "dbo.Candidate");
            DropForeignKey("dbo.Interviewer", "CompanyId", "dbo.Company");
            DropIndex("dbo.Interview", new[] { "QuestionAnswer_QuestionId" });
            DropIndex("dbo.Interview", new[] { "InterviewerId" });
            DropIndex("dbo.InterviewLoop", new[] { "Interviewer_InterviewerId" });
            DropIndex("dbo.InterviewLoop", new[] { "CompanyId" });
            DropIndex("dbo.InterviewLoop", new[] { "CandidateId" });
            DropIndex("dbo.Interviewer", new[] { "CompanyId" });
            DropTable("dbo.QuestionAnswer");
            DropTable("dbo.Interview");
            DropTable("dbo.InterviewLoop");
            DropTable("dbo.Interviewer");
            DropTable("dbo.Company");
            DropTable("dbo.Candidate");
        }
    }
}

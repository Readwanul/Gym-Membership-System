namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendences",
                c => new
                    {
                        serialNumber = c.Int(nullable: false, identity: true),
                        Attendance_date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        MemberID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.serialNumber)
                .ForeignKey("dbo.Members", t => t.MemberID, cascadeDelete: true)
                .Index(t => t.MemberID);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Age = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        PlanId = c.Int(nullable: false),
                        TrainerId = c.Int(nullable: false),
                        Membership_status = c.String(),
                        JoinedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plans", t => t.PlanId, cascadeDelete: true)
                .ForeignKey("dbo.Trainers", t => t.TrainerId, cascadeDelete: true)
                .Index(t => t.PlanId)
                .Index(t => t.TrainerId);
            
            CreateTable(
                "dbo.Plans",
                c => new
                    {
                        PlanId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        Trainer_Class = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PlanId);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        TrainerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Trainer_Class = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TrainerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendences", "MemberID", "dbo.Members");
            DropForeignKey("dbo.Members", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.Members", "PlanId", "dbo.Plans");
            DropIndex("dbo.Members", new[] { "TrainerId" });
            DropIndex("dbo.Members", new[] { "PlanId" });
            DropIndex("dbo.Attendences", new[] { "MemberID" });
            DropTable("dbo.Trainers");
            DropTable("dbo.Plans");
            DropTable("dbo.Members");
            DropTable("dbo.Attendences");
        }
    }
}

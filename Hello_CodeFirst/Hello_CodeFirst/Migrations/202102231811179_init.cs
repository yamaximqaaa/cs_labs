namespace Hello_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.email",
                c => new
                    {
                        EmId = c.Int(nullable: false, identity: true),
                        EmValue = c.String(),
                        IcId = c.String(),
                        Lecturer_LcId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EmId)
                .ForeignKey("dbo.Lecturers", t => t.Lecturer_LcId)
                .Index(t => t.Lecturer_LcId);
            
            CreateTable(
                "dbo.Lecturers",
                c => new
                    {
                        LcId = c.String(nullable: false, maxLength: 128),
                        LcFname = c.String(),
                        LcIName = c.String(),
                        Phone = c.String(),
                        Adress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                    })
                .PrimaryKey(t => t.LcId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.email", "Lecturer_LcId", "dbo.Lecturers");
            DropIndex("dbo.email", new[] { "Lecturer_LcId" });
            DropTable("dbo.Lecturers");
            DropTable("dbo.email");
        }
    }
}

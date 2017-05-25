namespace proyectoFinalSI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "patientId", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "doctorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "patientId");
            CreateIndex("dbo.Appointments", "doctorId");
            AddForeignKey("dbo.Appointments", "doctorId", "dbo.Doctors", "doctorId", cascadeDelete: true);
            AddForeignKey("dbo.Appointments", "patientId", "dbo.Patients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "patientId", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "doctorId", "dbo.Doctors");
            DropIndex("dbo.Appointments", new[] { "doctorId" });
            DropIndex("dbo.Appointments", new[] { "patientId" });
            DropColumn("dbo.Appointments", "doctorId");
            DropColumn("dbo.Appointments", "patientId");
        }
    }
}

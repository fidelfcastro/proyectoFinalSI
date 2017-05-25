namespace proyectoFinalSI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        appointmentId = c.Int(nullable: false, identity: true),
                        status = c.String(),
                        date = c.DateTime(nullable: false),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.appointmentId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        doctorId = c.Int(nullable: false, identity: true),
                        speciality = c.String(),
                        firstName = c.String(),
                        lastName = c.String(),
                        userName = c.String(),
                        password = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.doctorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Doctors");
            DropTable("dbo.Appointments");
        }
    }
}

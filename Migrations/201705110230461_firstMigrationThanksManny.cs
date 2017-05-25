namespace proyectoFinalSI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigrationThanksManny : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        userName = c.String(),
                        password = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Patients");
        }
    }
}

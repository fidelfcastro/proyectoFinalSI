namespace proyectoFinalSI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recipeToAppointmentMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "recipe", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "recipe");
        }
    }
}

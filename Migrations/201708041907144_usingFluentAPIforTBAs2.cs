namespace CompanyDbWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usingFluentAPIforTBAs2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TBALocations", name: "Csl_Assigned_INITIALS", newName: "Csl_Assigned_INITIAL");
            RenameIndex(table: "dbo.TBALocations", name: "IX_Csl_Assigned_INITIALS", newName: "IX_Csl_Assigned_INITIAL");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TBALocations", name: "IX_Csl_Assigned_INITIAL", newName: "IX_Csl_Assigned_INITIALS");
            RenameColumn(table: "dbo.TBALocations", name: "Csl_Assigned_INITIAL", newName: "Csl_Assigned_INITIALS");
        }
    }
}

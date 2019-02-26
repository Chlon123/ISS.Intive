namespace IIS.Web.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertyToSpaceStationData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpaceStationDatas", "InitialTimestamp", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SpaceStationDatas", "InitialTimestamp");
        }
    }
}

namespace IIS.Web.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpaceStationDatas", "Timestamp1", c => c.Double(nullable: false));
            AddColumn("dbo.SpaceStationDatas", "Timestamp2", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SpaceStationDatas", "Timestamp2");
            DropColumn("dbo.SpaceStationDatas", "Timestamp1");
        }
    }
}

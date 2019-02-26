namespace IIS.Web.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSpaceStationDataModel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.SpaceStationDatas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SpaceStationDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude1 = c.Double(nullable: false),
                        Longitude1 = c.Double(nullable: false),
                        Latitude2 = c.Double(nullable: false),
                        Longitude2 = c.Double(nullable: false),
                        InitialTimestamp = c.Double(nullable: false),
                        Timestamp1 = c.Double(nullable: false),
                        Timestamp2 = c.Double(nullable: false),
                        Message1 = c.String(),
                        Message2 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}

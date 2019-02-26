namespace IIS.Web.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelForControllerActions : DbMigration
    {
        public override void Up()
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
                        Message1 = c.String(),
                        Message2 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SpaceStationDatas");
        }
    }
}

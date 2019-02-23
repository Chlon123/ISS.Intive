namespace IIS.Web.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedPreviousVersionAndAddedDataModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalculationDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EarthRadius = c.Double(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Graphics");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Graphics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Data = c.Binary(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.CalculationDatas");
        }
    }
}

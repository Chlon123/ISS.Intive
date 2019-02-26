namespace IIS.Web.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCalculationData : DbMigration
    {
        public override void Up()
        {
            Sql("insert into CalculationDatas (EarthRadius, Description) values (6371000, 'The radius of the Earth based on Wikipedia')");
        }

        public override void Down()
        {
            Sql("delete from CalculationDatas where EarthRadius = 6371000");
        }
    }
}

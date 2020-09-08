namespace HotelWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstEdit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "NumberOfPersons", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "NumberOfPersons");
        }
    }
}

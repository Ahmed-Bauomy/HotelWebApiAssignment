namespace HotelWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondEdit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "Branch_BranchId", "dbo.Branches");
            DropIndex("dbo.Rooms", new[] { "Branch_BranchId" });
            RenameColumn(table: "dbo.Rooms", name: "Branch_BranchId", newName: "BranchId");
            AddColumn("dbo.Bookings", "BookingApproved", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Rooms", "BranchId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rooms", "BranchId");
            AddForeignKey("dbo.Rooms", "BranchId", "dbo.Branches", "BranchId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "BranchId", "dbo.Branches");
            DropIndex("dbo.Rooms", new[] { "BranchId" });
            AlterColumn("dbo.Rooms", "BranchId", c => c.Int());
            DropColumn("dbo.Bookings", "BookingApproved");
            RenameColumn(table: "dbo.Rooms", name: "BranchId", newName: "Branch_BranchId");
            CreateIndex("dbo.Rooms", "Branch_BranchId");
            AddForeignKey("dbo.Rooms", "Branch_BranchId", "dbo.Branches", "BranchId");
        }
    }
}

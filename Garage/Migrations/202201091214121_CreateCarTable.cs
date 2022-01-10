namespace Garage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCarTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnersName = c.String(),
                        CarNumber = c.Int(nullable: false),
                        FixedStatus = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
           DropTable("dbo.Cars");
        }
    }
}

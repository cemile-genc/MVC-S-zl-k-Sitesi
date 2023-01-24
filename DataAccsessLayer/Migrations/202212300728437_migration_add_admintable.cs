namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_add_admintable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminName = c.String(maxLength: 100),
                        AdminPassword = c.String(maxLength: 100),
                        AdminRole = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.AdminId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admins");
        }
    }
}

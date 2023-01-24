namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_contactadddatetime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Messages", "MessageContent", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "MessageContent", c => c.String(maxLength: 100));
            DropColumn("dbo.Contacts", "ContactDate");
        }
    }
}

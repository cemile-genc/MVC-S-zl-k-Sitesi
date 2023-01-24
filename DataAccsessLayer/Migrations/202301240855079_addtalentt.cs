namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtalentt : DbMigration
    {
        public override void Up()
        {

			CreateTable(
				"dbo.Talent",
				c => new
				{
					TalentID = c.Int(nullable: false, identity: true),
					Name = c.String(maxLength: 100),
					About = c.String(maxLength: 100),
					Skill1 = c.String(maxLength: 100),
					Skill2 = c.String(maxLength: 100),
					Skill3 = c.String(maxLength: 100),
					Skill4 = c.String(maxLength: 100),
					Skill5 = c.String(maxLength: 100),
				})
				.PrimaryKey(t => t.TalentID);
		}
        
        public override void Down()
        {
			DropTable("dbo.Talent");
		}
    }
}

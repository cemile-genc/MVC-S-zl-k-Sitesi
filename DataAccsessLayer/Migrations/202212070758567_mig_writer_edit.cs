namespace DataAccsessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_writer_edit : DbMigration
    {
        public override void Up() // güncellenecek veri update-database dersem bu çalışır
        {
            AddColumn("dbo.Writers", "WriterAbout", c => c.String(maxLength: 500)); //sütun ekle
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterAbout");
        }
    }
}

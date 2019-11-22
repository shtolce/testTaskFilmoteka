namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fopurth3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FilmInfoes", "Info", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FilmInfoes", "Info", c => c.String(maxLength: 40));
        }
    }
}

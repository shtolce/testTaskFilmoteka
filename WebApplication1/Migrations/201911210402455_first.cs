namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FilmInfoes", "Year", c => c.Int(nullable: false));
            AlterColumn("dbo.FilmInfoes", "Info", c => c.String(maxLength: 240));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FilmInfoes", "Info", c => c.String());
            DropColumn("dbo.FilmInfoes", "Year");
        }
    }
}

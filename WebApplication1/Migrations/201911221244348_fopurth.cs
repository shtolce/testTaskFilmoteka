namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fopurth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FilmInfoes", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.FilmInfoes", "User", c => c.String(nullable: false, maxLength: 26));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FilmInfoes", "User", c => c.String(nullable: false));
            AlterColumn("dbo.FilmInfoes", "Name", c => c.String(nullable: false));
        }
    }
}

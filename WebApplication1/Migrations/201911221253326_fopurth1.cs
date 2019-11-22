namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fopurth1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FilmInfoes", "User", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FilmInfoes", "User", c => c.String(nullable: false, maxLength: 26));
        }
    }
}

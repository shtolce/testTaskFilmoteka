namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fopurth2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FilmInfoes", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FilmInfoes", "Email", c => c.String(nullable: false));
        }
    }
}

namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seon : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FilmInfoes", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.FilmInfoes", new[] { "Genre_Id" });
            AlterColumn("dbo.FilmInfoes", "Genre_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.FilmInfoes", "Genre_Id");
            AddForeignKey("dbo.FilmInfoes", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilmInfoes", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.FilmInfoes", new[] { "Genre_Id" });
            AlterColumn("dbo.FilmInfoes", "Genre_Id", c => c.Int());
            CreateIndex("dbo.FilmInfoes", "Genre_Id");
            AddForeignKey("dbo.FilmInfoes", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}

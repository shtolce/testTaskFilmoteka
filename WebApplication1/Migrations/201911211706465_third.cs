namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.FilmInfoes", name: "Genre_Id", newName: "GenreId");
            RenameIndex(table: "dbo.FilmInfoes", name: "IX_Genre_Id", newName: "IX_GenreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.FilmInfoes", name: "IX_GenreId", newName: "IX_Genre_Id");
            RenameColumn(table: "dbo.FilmInfoes", name: "GenreId", newName: "Genre_Id");
        }
    }
}

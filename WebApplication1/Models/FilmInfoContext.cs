using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Models
{

    public class FilmInfoContextInitializer : CreateDatabaseIfNotExists<FilmInfoContext>
    {
        protected override void Seed(FilmInfoContext db)
        {
            Genre Dramma = new Genre { Name = "Dramma"};
            Genre Horror = new Genre { Name = "Horror" };
            Genre Triller = new Genre { Name = "Triller" };
            Genre SciFi = new Genre { Name = "SciFi" };
            Genre All = new Genre { Name = "Все" };
            db.Genres.Add(Dramma);
            db.Genres.Add(Horror);
            db.Genres.Add(Triller);
            db.Genres.Add(SciFi);

            db.SaveChanges();
        }
    }


    public class FilmInfoContext:DbContext
    {
        public FilmInfoContext():base("DefaultConnection")
        {
            Database.SetInitializer<FilmInfoContext>(new FilmInfoContextInitializer());
        }

        public DbSet<FilmInfo> FilmInfoCatalog { get; set;}
        public DbSet<Genre> Genres { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            base.OnModelCreating(modelBuilder);
        }


    }
}
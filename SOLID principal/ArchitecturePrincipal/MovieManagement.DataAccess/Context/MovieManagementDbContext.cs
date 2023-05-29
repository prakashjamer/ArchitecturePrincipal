using Microsoft.EntityFrameworkCore;
using MovieManagementDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.Context
{
    public class MovieManagementDbContext : DbContext
    {
        public MovieManagementDbContext(DbContextOptions<MovieManagementDbContext> options) : base(options)
        {

        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Biography> Biographies { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().Property(t => t.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Movie>().Property(t => t.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Actor>()
             .HasMany(t => t.Movies)
             .WithMany(t => t.Actors).UsingEntity(c => c.ToTable("ActorMovie"));
            modelBuilder.Entity<Actor>().HasData(
               new Actor() { Id = 1, Name = "Hritik", LastName = "Roshan" }
               );
            modelBuilder.Entity<Movie>().HasData(
                new Movie() { Id = 1, Name = "Kaho Na Payar Hein", Description = "Released in 2000" }
                );
            //modelBuilder.Entity<ActorMovie>().HasKey(am => new { am.ActorId, am.MovieId });
            //modelBuilder.Entity<ActorMovie>().HasData(
            //   new ActorMovie() { ActorId = 1, MovieId = 1 }
            //   );
         

            //modelBuilder.Entity<ActorMovies>()
            //.HasOne<Actor>(sc => sc.Actor)
            //.WithMany(s => s.ActorMovies)
            //.HasForeignKey(sc => sc.ActorId);


            //modelBuilder.Entity<ActorMovies>()
            //.HasOne<Movie>(sc => sc.Movie)
            //.WithMany(s => s.ActorMovies)
            //.HasForeignKey(sc => sc.MovieId);

        }


    }
}

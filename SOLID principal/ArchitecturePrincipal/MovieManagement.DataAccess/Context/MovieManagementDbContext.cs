using Microsoft.EntityFrameworkCore;
using MovieManagementDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.Context
{
    public class MovieManagementDbContext:DbContext
    {
        public MovieManagementDbContext(DbContextOptions<MovieManagementDbContext> options):base(options)
        {

        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Biography> Biographies { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().HasData(
                new Actor() {Id=1, Name="Hritik",LastName="Roshan" }
                ); ;
        }

    }
}

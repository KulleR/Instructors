using System;
using Instructors.WebApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Instructors.WebApi.Data
{
    /// <summary>
    /// A DatabaseContext instance that can be used to query from a database 
    /// and group together changes that will then be written back to the store as a unit
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DbSet<Instructor> Instructors { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instructor>().HasData(
                new Instructor() { Id = 1, FirstName= "Michelangelo", MiddleName = "", LastName = "Buonarroti"},
                new Instructor() { Id = 2, FirstName = "Leonardo", MiddleName = "", LastName = "da Vinci" },
                new Instructor() { Id = 3, FirstName = "Vandinelli", MiddleName = "", LastName = "Bartolommeo" },
                new Instructor() { Id = 4, FirstName = "Lorenzo", MiddleName = "", LastName = "Ghiberti" },
                new Instructor() { Id = 5, FirstName = "Benvenuto", MiddleName = "", LastName = "Cellini" },
                new Instructor() { Id = 6, FirstName = "Bernando", MiddleName = "", LastName = "Rossellino" },
                new Instructor() { Id = 7, FirstName = "Guido", MiddleName = "", LastName = "Mazzoni" },
                new Instructor() { Id = 8, FirstName = "Pietro", MiddleName = "", LastName = "Torrigiano" },
                new Instructor() { Id = 9, FirstName = "Diego", MiddleName = "", LastName = "Siloe" },
                new Instructor() { Id = 10, FirstName = "Matteo", MiddleName = "", LastName = "Civitali" },
                new Instructor() { Id = 11, FirstName = "Viet", MiddleName = "", LastName = "Stoss" },
                new Instructor() { Id = 12, FirstName = "Alessandro", MiddleName = "", LastName = "Vittoria" });
        }
    }
}

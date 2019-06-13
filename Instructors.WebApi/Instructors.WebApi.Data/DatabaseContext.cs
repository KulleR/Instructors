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
    }
}

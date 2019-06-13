using System;
using Instructors.WebApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Instructors.WebApi.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Instructor> Blogs { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        { }
    }
}

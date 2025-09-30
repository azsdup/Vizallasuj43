using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Vizallasuj2.Models;

namespace Vizallasuj2.Data
{
    public class vizDbContext : DbContext
    {
        public vizDbContext(DbContextOptions<vizDbContext> options)
           : base(options) { }

        public DbSet<Víz> Vízállás { get; set; }
    }
}

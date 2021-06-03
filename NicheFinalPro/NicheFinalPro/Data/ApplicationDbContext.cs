using System;
using Microsoft.EntityFrameworkCore;
using NicheFinalPro.Models;

namespace NicheFinalPro.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Event> Events { get; set; }
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

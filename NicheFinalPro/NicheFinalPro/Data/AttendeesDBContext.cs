using System;
using Microsoft.EntityFrameworkCore;
using NicheFinalPro.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NicheFinalPro.Data
{
    public class AttendeesDBContext : DbContext
    {
        public virtual DbSet<EventAttendees> AttendeeTable { get; set; }


        public AttendeesDBContext(DbContextOptions<AttendeesDBContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
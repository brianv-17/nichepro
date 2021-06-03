using System;
using Microsoft.EntityFrameworkCore;
using NicheFinalPro.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NicheFinalPro.Data
{
    public class UserContext : IdentityDbContext<User>
    {
        public virtual DbSet<User> UserTable { get; set; }


        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

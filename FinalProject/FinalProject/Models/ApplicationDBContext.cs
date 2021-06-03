using System;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }
        public DbSet<Event> Events { get; set; }
        
    }
}

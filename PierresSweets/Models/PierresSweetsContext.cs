using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PierresSweets.Models
{
    public class PierresSweetsContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Flavor> Flavors { get; set; }
        public virtual DbSet<Treat> Treats { get; set; }
        public virtual DbSet<FlavorTreat> FalvorTreat { get; set; }

        public PierresSweetsContext(DbContextOptions options) : base(options) { }
    }
}
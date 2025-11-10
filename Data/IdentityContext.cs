using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WarrantyAPITest.Models;

namespace WarrantyAPITest.Data
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
        : base(options)
        {
        }

      //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      //=> optionsBuilder.UseSqlServer("Name=ConnectionStrings:IdentityDbConnection");
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // MUST call base to configure Identity keys
        }

    }
}

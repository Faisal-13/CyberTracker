using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CyberTracker.Models;

namespace CyberTracker.Data
{
    // Inherit from IdentityDbContext to get all the User/Role tables automatically
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Incident> Incidents { get; set; }
        public DbSet<SecurityTip> SecurityTips { get; set; }
    }
}
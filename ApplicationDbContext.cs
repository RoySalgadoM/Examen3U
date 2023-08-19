using Examen3U.Models;
using Microsoft.EntityFrameworkCore;

namespace Examen3U
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Medicine>? Medicines { get; set; }
        public DbSet<Owner>? Owners { get; set; }  

    }
}
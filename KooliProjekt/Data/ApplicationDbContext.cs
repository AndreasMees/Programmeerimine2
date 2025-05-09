using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<CarCare> CarCares { get; set; }
        public DbSet<CarDisplacement> CarDisplacements { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<Wash> Washes { get; set; }
        public DbSet<Operation> Operations { get; set; }
    }
}

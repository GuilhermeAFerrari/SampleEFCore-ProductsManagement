using Microsoft.EntityFrameworkCore;
using SampleEFCore_ProductsManagement.Domain;

namespace SampleEFCore_ProductsManagement.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;
                Database=EFCore_ProductsManagement;
                User ID=sa;Password=1q2w3e4r@#$;
                TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}

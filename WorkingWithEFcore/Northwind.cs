using Microsoft.EntityFrameworkCore;
namespace WorkingWithEFcore
{
    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Northwind.db");
            optionsBuilder.UseLazyLoadingProxies().UseSqlite($"Filename = {path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API
            modelBuilder.Entity<Category>()
            .Property(category => category.CategoryName)
            .IsRequired() // NOT NULL
            .HasMaxLength(15);

            // for the convertion of money
            modelBuilder.Entity<Product>()
            .Property(p => p.Cost)
            .HasConversion<double>();

            // global filter
            modelBuilder.Entity<Product>()
            .HasQueryFilter(p => !p.Discontinued);
        }

    }
}
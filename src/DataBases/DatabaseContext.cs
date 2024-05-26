using Microsoft.EntityFrameworkCore;
using Npgsql;
namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
        public class DatabaseContext : DbContext
        {
                public DbSet<Order> Order { get; set; }
                public DbSet<Product> Product { get; set; }
                public DbSet<User> User { get; set; }
                public DbSet<OrderItem> OrderItem { get; set; }
                public DbSet<Address> Addresses { get; set; }
                public DbSet<Category> Category { get; set; }
                public DbSet<Payment> Payment { get; set; }
                public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }



                protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                        modelBuilder.HasPostgresEnum<Role>();
                        modelBuilder.HasPostgresEnum<ProductSize>();
                        modelBuilder.HasPostgresEnum<Status>();


                }
        }
}
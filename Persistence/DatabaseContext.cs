using Microsoft.EntityFrameworkCore;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Persistence
{
    public class DatabaseContext : DbContext
    {
            
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venda>().Navigation(e => e.Produtos).AutoInclude();
            modelBuilder.Entity<Venda>().Navigation(e => e.Vendedor).AutoInclude();
        }

        public DbSet<Venda> Vendas { get; set; }
   
    }
}

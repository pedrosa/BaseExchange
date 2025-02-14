using BaseExchange.OrderGenerator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseExchange.OrderGenerator.Infrastructure.Persistence
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Symbol).IsRequired();
                entity.Property(e => e.Side).IsRequired();
                entity.OwnsOne(e => e.Quantity, q =>
                {
                    q.Property(p => p.Value).HasColumnName("Quantity");
                });
                entity.OwnsOne(e => e.Price, p =>
                {
                    p.Property(p => p.Value).HasColumnName("Price").HasPrecision(18, 2);
                });
            });
        }
    }
}
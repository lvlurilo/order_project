using Microsoft.EntityFrameworkCore;
using OrderApi.src.Domain.Entities;

namespace OrderApi.src.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {}

    public DbSet<Order> Orders => Set<Order>();

    public DbSet<Item> Items => Set<Item>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(x => x.Id);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(x => x.Id);
        });
    }
}
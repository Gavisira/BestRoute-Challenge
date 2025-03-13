using BestRoute.Models;
using Microsoft.EntityFrameworkCore;

namespace BestRoute.Database.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<RouteEntity> Routes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        //Adicionando diretamente no context, mas costumeiramente é feito em um arquivo de configuração

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<RouteEntity>().HasKey(r => r.Id);
        modelBuilder.Entity<RouteEntity>().Property(r => r.Origin).IsRequired();
        modelBuilder.Entity<RouteEntity>().Property(r => r.Destination).IsRequired();
        modelBuilder.Entity<RouteEntity>().Property(r => r.Price).HasColumnType("decimal(10,2)");
    }
}

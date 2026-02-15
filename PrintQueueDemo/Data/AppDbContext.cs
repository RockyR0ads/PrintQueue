using Microsoft.EntityFrameworkCore;
using PrintQueueDemo.Models;

namespace PrintQueueDemo.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<PrintJob> PrintJobs => Set<PrintJob>();
    public DbSet<PricingConfig> PricingConfig => Set<PricingConfig>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PricingConfig>().HasData(
            new PricingConfig
            {
                Id = 1,
                ElectricityCostPerKwh = 0.30m
            }
        );
    }

}

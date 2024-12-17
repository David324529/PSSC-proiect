using Microsoft.EntityFrameworkCore;
using ProjectMagazin_3_Workflows.Data.Models;

public class AppDbContext : DbContext
{
    // DbSets for your DTOs (DeliveryDto, InvoiceDto, OrderDto)
    public DbSet<DeliveryDto> Deliveries { get; set; }
    public DbSet<InvoiceDto> Invoices { get; set; }
    public DbSet<OrderDto> Orders { get; set; }

    // Constructor accepting DbContextOptions
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) // Pass the options to the base DbContext constructor
    { }

    // Override OnModelCreating to define keyless entities
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Mark DTOs as keyless
        modelBuilder.Entity<DeliveryDto>().HasNoKey();
        modelBuilder.Entity<InvoiceDto>().HasNoKey();
        modelBuilder.Entity<OrderDto>().HasNoKey();
    }
}
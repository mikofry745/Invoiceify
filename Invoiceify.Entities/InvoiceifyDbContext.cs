using Invoiceify.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invoiceify.Entities;

public class InvoiceifyDbContext : DbContext
{
    private const string _connectionString = 
        "Server=localhost;Database=InvoiceifyDb;Trusted_Connection=True;";
    
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<BusinessProfile> BusinessProfiles { get; set; }
    public DbSet<Business> Businesses { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InvoiceCustomer>(e => {
            e.HasOne(c => c.IssuerInvoice).WithOne(i => i.Issuer)
                .HasForeignKey<Invoice>(i => i.IssuerId).IsRequired(false);
            e.HasOne(c => c.RecipientInvoice).WithOne(i => i.Recipient)
                .HasForeignKey<Invoice>(i => i.RecipientId).IsRequired(false);
        });
    }
}
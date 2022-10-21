namespace Invoiceify.Entities.Entities;

public class Business
{
    public int Id { get; set; }
    public string? DefaultInvoiceNote { get; set; }
    public virtual BusinessProfile? Profile { get; set; }
    
    public ICollection<Product> Products { get; set; }
    public ICollection<Customer> Customers { get; set; }
    public ICollection<Invoice> Invoices { get; set; }
}
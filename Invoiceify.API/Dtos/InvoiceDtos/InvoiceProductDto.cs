using Invoiceify.Entities.Enums;

namespace Invoiceify.API.Dtos.InvoiceDtos;

public class InvoiceProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public UnitType UnitType { get; set; }
    public double Quantity { get; set; }
    public string? Description { get; set; }
    public int? TaxPercentage { get; set; }
}
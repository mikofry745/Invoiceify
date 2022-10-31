using Invoiceify.API.Dtos.CustomerDtos;
using Invoiceify.API.Dtos.ProductDtos;
using Invoiceify.Entities.Enums;

namespace Invoiceify.API.Dtos.InvoiceDtos;

public class InvoiceDto
{
    public int Id { get; set; }
    public string Number { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime IssueDate { get; set; }
    public InvoiceType Type { get; set; }
    public CurrencyType Currency { get; set; }
    public string Note { get; set; }
    public double SubTotal { get; set; }
    public double TotalShiping { get; set; }
    public double TotalPrice { get; set; }
    public double? TotalTax { get; set; }
    public DateTime? PaymentDate { get; set; }
    
    public int IssuerId { get; set; }
    public CustomerDto Issuer { get; set; }
    
    public int RecipientId { get; set; }
    public CustomerDto Recipient { get; set; }
    public List<InvoiceProductDto> Products { get; set; }
}
using System.ComponentModel.DataAnnotations;
using Invoiceify.Entities.Enums;

namespace Invoiceify.Entities.Entities;

public class Invoice
{
    public int Id { get; set; }
    
    [Required]
    public string Number { get; set; }
    [Required]
    public DateTime DueDate { get; set; }
    [Required]
    public DateTime IssueDate { get; set; }
    [Required]
    public InvoiceType Type { get; set; }
    [Required]
    public CurrencyType Currency { get; set; }
    [Required]
    public string Note { get; set; }
    [Required]
    public double SubTotal { get; set; }
    [Required]
    public double TotalShiping { get; set; }
    [Required]
    public double TotalPrice { get; set; }
    
    public double? TotalTax { get; set; }
    public DateTime? PaymentDate { get; set; }
    
    public int IssuerId { get; set; }
    public virtual InvoiceCustomer? Issuer { get; set; }

    public int RecipientId { get; set; }
    public virtual InvoiceCustomer? Recipient { get; set; }

    public virtual ICollection<InvoiceProduct>? Products { get; set; }
    
    public int BusinessId { get; set; }
    public Business? Business { get; set; }
}
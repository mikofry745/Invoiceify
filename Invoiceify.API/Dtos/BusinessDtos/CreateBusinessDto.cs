using System.ComponentModel.DataAnnotations;

namespace Invoiceify.API.Dtos.InvoiceDtos;

public class CreateBusinessDto
{
    [Required]
    public bool IsOrganization { get; set; }
    public string? DefaultInvoiceNote { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Street { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string PostalCode { get; set; }
    [Required]
    public string TaxIdentificationNumber { get; set; }
    [Required]
    public string EmailAddress { get; set; }
}
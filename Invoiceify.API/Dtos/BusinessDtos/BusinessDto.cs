using Invoiceify.API.Dtos.CustomerDtos;
using Invoiceify.API.Dtos.ProductDtos;

namespace Invoiceify.API.Dtos.InvoiceDtos;

public class BusinessDto
{
    public int Id { get; set; }
    public bool IsOrganization { get; set; }
    public string? DefaultInvoiceNote { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string? TaxIdentificationNumber { get; set; }
    public string? EmailAddress { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Country { get; set; }
    public List<ProductDto> Products { get; set; }
    public List<CustomerDto> Customers { get; set; }
    
}
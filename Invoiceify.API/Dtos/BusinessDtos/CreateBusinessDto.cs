namespace Invoiceify.API.Dtos.InvoiceDtos;

public class CreateBusinessDto
{
    public bool IsOrganization { get; set; }
    public string? DefaultInvoiceNote { get; set; }
    public string Name { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string TaxIdentificationNumber { get; set; }
    public string EmailAddress { get; set; }
}
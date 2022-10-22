namespace Invoiceify.API.Dtos.InvoiceDtos;

public class BusinessBasicInformationDto
{
    public int Id { get; set; }
    public bool IsOrganization { get; set; }
    public string? EmailAddress { get; set; }
    public string? Name { get; set; }
}
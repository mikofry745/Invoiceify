namespace Invoiceify.API.Dtos.CustomerDtos;

public class UpdateCustomerDto
{
    public string Street { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string TaxIdentificationNumber { get; set; }
    public string EmailAddress { get; set; }
    public string Name { get; set; }
    public bool IsOrganization { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Country { get; set; }
}
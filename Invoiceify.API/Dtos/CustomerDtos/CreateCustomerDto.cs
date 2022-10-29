using System.ComponentModel.DataAnnotations;

namespace Invoiceify.API.Dtos.CustomerDtos;

public class CreateCustomerDto
{
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
    [Required]
    public string Name { get; set; }
    [Required]
    public bool IsOrganization { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Country { get; set; }
    
    public int BusinessId { get; set; }
}
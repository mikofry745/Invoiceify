using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoiceify.Entities.Entities;

public class BusinessProfile
{
    [ForeignKey("Business")]
    public int Id { get; set; }
    
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

    public string? PhoneNumber { get; set; }
    public string? Country { get; set; }

    public virtual Business? Business { get; set; }
}
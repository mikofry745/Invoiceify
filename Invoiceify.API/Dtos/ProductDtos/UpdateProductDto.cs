using Invoiceify.Entities.Enums;

namespace Invoiceify.API.Dtos.ProductDtos;

public class UpdateProductDto
{
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public UnitType UnitType { get; set; }
    public string? Description { get; set; }
    public int? TaxPercentage { get; set; }
}
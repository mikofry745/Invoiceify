using Invoiceify.Entities.Enums;

namespace Invoiceify.API.Dtos.ProductDtos;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public UnitType UnitType { get; set; }
    public string? Description { get; set; }
    public int? TaxPercentage { get; set; }

    public string GrossPrice
    {
        get
        {
            if (TaxPercentage is > 0)
            {
                var grossPrice = UnitPrice + (UnitPrice * ((decimal)TaxPercentage / 100));
                return grossPrice.ToString("0.00");
            }

            return UnitPrice.ToString("0.00");
        }
    }
}
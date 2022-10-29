using Invoiceify.API.Dtos.ProductDtos;

namespace Invoiceify.API.Services.Interfaces;

public interface IProductService
{
    Task<int> CreateProductAsync(int businessId, CreateProductDto createProductDto);
    Task DeleteProductAsync(int businessId, int productId);
    Task UpdateProductAsync(int businessId, int productId, UpdateProductDto updateProductDto);
    Task<IEnumerable<ProductDto>> GetAllProductsAsync(int businessId);
    Task<ProductDto> GetProductByIdAsync(int productId, int businessId);
}
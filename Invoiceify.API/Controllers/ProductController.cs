using Invoiceify.API.Dtos.ProductDtos;
using Invoiceify.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Invoiceify.API.Controllers;

[Route("api/businesses/{businessId}/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Creates and saves a product to the database based on the given parameters
    /// </summary>
    /// <param name="businessId">Id of a business</param>
    /// <param name="createProductDto">Parameters of the created product</param>
    /// <returns>Status created (201) with the path to the created product</returns>
    [HttpPost("new")]
    public async Task<IActionResult> CreateAsync([FromRoute]int businessId, [FromBody]CreateProductDto createProductDto)
    {
        var productId = await _productService.CreateProductAsync(businessId, createProductDto);

        return Created($"/api/{businessId}/product/{productId}", null);
    }
    
    /// <summary>
    /// Deletes the product with the specified id
    /// </summary>
    /// <param name="businessId">Id of a business</param>
    /// <param name="productId">Id of a product</param>
    /// <returns>Status no content (204)</returns>
    [HttpDelete("delete/{productId}")]
    public async Task<IActionResult> DeleteAsync([FromRoute]int businessId, [FromRoute]int productId)
    {
        await _productService.DeleteProductAsync(businessId, productId);
    
        return NoContent();
    }

    /// <summary>
    /// Updates the parameters of the selected product to the given parameters
    /// </summary>
    /// <param name="businessId">Id of a business</param>
    /// <param name="productId">Id of a product</param>
    /// <param name="updateProductDto">Parameters to which the product parameters will be changed</param>
    /// <returns>Status ok (200)</returns>
    [HttpPut("update/{productId}")]
    public async Task<IActionResult> UpdateAsync([FromRoute]int businessId, [FromRoute] int productId, [FromBody]UpdateProductDto updateProductDto)
    {
        await _productService.UpdateProductAsync(businessId, productId, updateProductDto);
    
        return Ok();
    }
    
    /// <summary>
    /// Returns all available products assigned to given business
    /// </summary>
    /// <param name="businessId">Id of a business</param>
    /// <returns>List of products</returns>
    [HttpGet ()]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllAsync([FromRoute]int businessId)
    {
        var products = await _productService.GetAllProductsAsync(businessId);
    
        return products != null ? Ok(products) : NotFound();
    }
    
    /// <summary>
    /// Returns the product with the given id assigned to given business
    /// </summary>
    /// <param name="businessId">Id of a business</param>
    /// <param name="productId">Id of a product</param>
    /// <returns>Product</returns>
    [HttpGet("{productId}")]
    public async Task<ActionResult<ProductDto>> GetByIdAsync([FromRoute]int businessId, [FromRoute] int productId)
    {
        var product = await _productService.GetProductByIdAsync(productId, businessId);
    
        return product != null ? Ok(product) : NotFound();
    }
}
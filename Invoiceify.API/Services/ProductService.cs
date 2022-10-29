using AutoMapper;
using Invoiceify.API.Dtos.ProductDtos;
using Invoiceify.API.Exceptions;
using Invoiceify.API.Services.Interfaces;
using Invoiceify.Entities;
using Invoiceify.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invoiceify.API.Services;

public class ProductService : IProductService
{
    private readonly InvoiceifyDbContext _dbContext;
    private readonly IMapper _mapper;

    public ProductService(InvoiceifyDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<int> CreateProductAsync(int businessId, CreateProductDto createProductDto)
    {
        var business = await _dbContext
            .Businesses
            .Include(b => b.Products)
            .FirstOrDefaultAsync(p => p.Id == businessId);

        if (business is null)
        {
            throw new NotFoundException($"Business with given id: {businessId} not found");
        }

        var product = _mapper.Map<Product>(createProductDto);
        product.BusinessId = businessId;
        
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();

        return product.Id;
    }
    
    public async Task DeleteProductAsync(int businessId, int productId)
    {
        var business = await _dbContext
            .Businesses
            .Include(b => b.Products)
            .FirstOrDefaultAsync(p => p.Id == businessId);

        if (business is null)
        {
            throw new NotFoundException($"Business with given id: {businessId} not found");
        }
        
        var product = business.Products.FirstOrDefault(p => p.Id == productId);

        if (product == null)
        {
            throw new NotFoundException($"Product with given id: {productId} not found");
        }

        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task UpdateProductAsync(int businessId, int productId, UpdateProductDto updateProductDto)
    {
        var business = await _dbContext
            .Businesses
            .Include(b => b.Products)
            .FirstOrDefaultAsync(p => p.Id == businessId);

        if (business is null)
        {
            throw new NotFoundException($"Business with given id: {businessId} not found");
        }
        
        var product = business.Products.FirstOrDefault(p => p.Id == productId);

        if (product == null)
        {
            throw new NotFoundException($"Product with given id: {productId} not found");
        }

        product.Name = updateProductDto.Name;
        product.Description = updateProductDto.Description;
        product.TaxPercentage = updateProductDto.TaxPercentage;
        product.UnitPrice = updateProductDto.UnitPrice;
        product.UnitType = updateProductDto.UnitType;
        
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(int businessId)
    {
        var business = await _dbContext
            .Businesses
            .Include(b => b.Products)
            .FirstOrDefaultAsync(p => p.Id == businessId);

        if (business is null)
        {
            throw new NotFoundException($"Business with given id: {businessId} not found");
        }

        var productDtos = _mapper.Map<List<ProductDto>>(business.Products);

        return productDtos;
    }

    public async Task<ProductDto> GetProductByIdAsync(int productId, int businessId)
    {
        var business = await _dbContext
            .Businesses
            .Include(b => b.Products)
            .FirstOrDefaultAsync(p => p.Id == businessId);

        if (business is null)
        {
            throw new NotFoundException($"Business with given id: {businessId} not found");
        }
        
        var product = business.Products.FirstOrDefault(p => p.Id == productId);

        if (product == null)
        {
            throw new NotFoundException($"Product with given id: {productId} not found");
        }

        var productDto = _mapper.Map<ProductDto>(product);
        
        return productDto;
    }
}
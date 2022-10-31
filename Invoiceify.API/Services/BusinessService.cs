using AutoMapper;
using Invoiceify.API.Dtos.InvoiceDtos;
using Invoiceify.API.Exceptions;
using Invoiceify.API.Services.Interfaces;
using Invoiceify.Entities;
using Invoiceify.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invoiceify.API.Services;

public class BusinessService : IBusinessService
{
    private readonly InvoiceifyDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<BusinessService> _logger;

    public BusinessService(InvoiceifyDbContext dbContext, IMapper mapper, ILogger<BusinessService> logger)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<int> CreateBusinessAsync(CreateBusinessDto createBusinessDto)
    {
        var business = _mapper.Map<Business>(createBusinessDto);
        business.Customers = new List<Customer>();
        business.Invoices = new List<Invoice>();
        business.Products = new List<Product>();

        await _dbContext.Businesses.AddAsync(business);
        await _dbContext.SaveChangesAsync();

        return business.Id;
    }

    public async Task DeleteBusinessAsync(int businessId)
    {
        _logger.LogWarning($"Business with id: {businessId} DELETE action invoked");
            
        var business = await _dbContext.Businesses
            .Include(b => b.Profile)
            .FirstOrDefaultAsync(b => b.Id == businessId);

        if (business is null)
        {
            throw new NotFoundException($"Business with given id: {businessId} not found");
        }

        _dbContext.Businesses.Remove(business);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateBusiness(int businessId, UpdateBusinessDto updateBusinessDto)
    {
        var business = await _dbContext.Businesses
            .Include(b => b.Profile)
            .FirstOrDefaultAsync(b => b.Id == businessId);

        if (business is null)
        {
            throw new NotFoundException($"Business with given id: {businessId} not found");
        }
        
        if (business.Profile is null)
        {
            business.Profile = new BusinessProfile();
        }
        
        business.DefaultInvoiceNote = updateBusinessDto.DefaultInvoiceNote;
        business.IsOrganization = updateBusinessDto.IsOrganization;
        business.Profile.Name = updateBusinessDto.Name;
        business.Profile.City = updateBusinessDto.City;
        business.Profile.Street = updateBusinessDto.Street;
        business.Profile.PostalCode = updateBusinessDto.PostalCode;
        business.Profile.Country = updateBusinessDto.Country;
        business.Profile.EmailAddress = updateBusinessDto.EmailAddress;
        business.Profile.PhoneNumber = updateBusinessDto.PhoneNumber;
        business.Profile.TaxIdentificationNumber = updateBusinessDto.TaxIdentificationNumber;
        
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<BusinessBasicInformationDto>> GetAllBusinessBasicInformationAsync()
    {
        var businesses = await _dbContext.Businesses
            .Include(b => b.Profile)
            .ToListAsync();
        
        var businessBasicInformationDtos = _mapper.Map<List<BusinessBasicInformationDto>>(businesses);

        return businessBasicInformationDtos;
    }

    public async Task<IEnumerable<BusinessDto>> GetAllBusinessesAsync()
    {
        var businesses = await _dbContext.Businesses
            .Include(b => b.Profile)
            .Include(b => b.Products)
            .Include(b => b.Customers)
            .Include(b => b.Invoices)
            .ToListAsync();
        
        var businessDtos = _mapper.Map<List<BusinessDto>>(businesses);

        return businessDtos;
    }

    public async Task<BusinessDto> GetBusinessByIdAsync(int businessId)
    {
        var businesses = await _dbContext.Businesses
            .Include(b => b.Profile)
            .Include(b => b.Customers)
            .FirstOrDefaultAsync(b => b.Id == businessId);

        if (businesses is null)
        {
            throw new NotFoundException($"Business with given id: {businessId} not found");
        }

        var businessDto = _mapper.Map<BusinessDto>(businesses);

        return businessDto;
    }
}
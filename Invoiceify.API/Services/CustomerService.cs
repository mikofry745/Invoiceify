using AutoMapper;
using Invoiceify.API.Dtos.CustomerDtos;
using Invoiceify.API.Exceptions;
using Invoiceify.API.Services.Interfaces;
using Invoiceify.Entities;
using Invoiceify.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invoiceify.API.Services;

public class CustomerService : ICustomerService
{
    private readonly InvoiceifyDbContext _dbContext;
    private readonly IMapper _mapper;

    public CustomerService(InvoiceifyDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<int> CreateCustomerAsync(int businessId, CreateCustomerDto createCustomerDto)
    {
        var business = await _dbContext
            .Businesses
            .Include(b => b.Customers)
            .FirstOrDefaultAsync(p => p.Id == businessId);

        if (business is null)
        {
            throw new NotFoundException($"Business with given id: {businessId} not found");
        }

        var customer = _mapper.Map<Customer>(createCustomerDto);
        customer.BusinessId = businessId;
        
        await _dbContext.Customers.AddAsync(customer);
        await _dbContext.SaveChangesAsync();

        return customer.Id;
    }
    
    public async Task DeleteCustomerAsync(int businessId, int customerId)
    {
        var business = await _dbContext
            .Businesses
            .Include(b => b.Customers)
            .FirstOrDefaultAsync(p => p.Id == businessId);

        if (business is null)
        {
            throw new NotFoundException($"Business with given id: {businessId} not found");
        }
        
        var customer = business.Customers.FirstOrDefault(c => c.Id == customerId);

        if (customer == null)
        {
            throw new NotFoundException($"Product with given id: {customerId} not found");
        }

        _dbContext.Customers.Remove(customer);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task UpdateCustomerAsync(int businessId, int customerId, UpdateCustomerDto updateCustomerDto)
    {
        var business = await _dbContext
            .Businesses
            .Include(b => b.Customers)
            .FirstOrDefaultAsync(p => p.Id == businessId);
        
        if (business is null)
        {
            throw new NotFoundException($"Business with given id: {businessId} not found");
        }
        
        var customer = business.Customers.FirstOrDefault(c => c.Id == customerId);

        if (customer == null)
        {
            throw new NotFoundException($"Product with given id: {customerId} not found");
        }

        customer.Name = updateCustomerDto.Name;
        customer.Street = updateCustomerDto.Street;
        customer.City = updateCustomerDto.City;
        customer.PostalCode = updateCustomerDto.PostalCode;
        customer.TaxIdentificationNumber = updateCustomerDto.TaxIdentificationNumber;
        customer.EmailAddress = updateCustomerDto.EmailAddress;
        customer.IsOrganization = updateCustomerDto.IsOrganization;
        customer.PhoneNumber = updateCustomerDto.PhoneNumber;
        customer.Country = updateCustomerDto.Country;
        
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync(int businessId)
    {
        var business = await _dbContext
            .Businesses
            .Include(b => b.Customers)
            .FirstOrDefaultAsync(p => p.Id == businessId);

        if (business is null)
        {
            throw new NotFoundException($"Business with given id: {businessId} not found");
        }

        var customerDtos = _mapper.Map<List<CustomerDto>>(business.Customers);

        return customerDtos;
    }

    public async Task<CustomerDto> GetCustomerByIdAsync(int customerId, int businessId)
    {
        var business = await _dbContext
            .Businesses
            .Include(b => b.Customers)
            .FirstOrDefaultAsync(p => p.Id == businessId);

        if (business is null)
        {
            throw new NotFoundException($"Business with given id: {businessId} not found");
        }
        
        var customer = business.Customers.FirstOrDefault(c => c.Id == customerId);

        if (customer == null)
        {
            throw new NotFoundException($"Product with given id: {customerId} not found");
        }

        var customerDto = _mapper.Map<CustomerDto>(customer);
        
        return customerDto;
    }
}
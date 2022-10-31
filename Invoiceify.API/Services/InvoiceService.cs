using AutoMapper;
using Invoiceify.API.Dtos.InvoiceDtos;
using Invoiceify.API.Exceptions;
using Invoiceify.API.Services.Interfaces;
using Invoiceify.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invoiceify.API.Services;

public class InvoiceService : IInvoiceService
{
    private readonly InvoiceifyDbContext _dbContext;
    private readonly IMapper _mapper;

    public InvoiceService(IMapper mapper, InvoiceifyDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync(int businessId)
    {
        var business = await _dbContext
            .Businesses
            .FirstOrDefaultAsync(b => b.Id == businessId);

        if (business is null)
        {
            throw new NotFoundException($"Business with given id: {businessId} not found");
        }
        
        var invoices = await _dbContext
            .Invoices
            .Where(i => i.BusinessId == businessId)
            .Include(i => i.Products)
            .Include(i => i.Recipient)
            .Include(i => i.Issuer)
            .ToListAsync();

        var invoiceDtos = _mapper.Map<List<InvoiceDto>>(invoices);

        return invoiceDtos;
    }

    public async Task<InvoiceDto> GetInvoiceByIdAsync(int invoiceId, int businessId)
    {
        var business = await _dbContext
            .Businesses
            .FirstOrDefaultAsync(b => b.Id == businessId);

        if (business is null)
        {
            throw new NotFoundException($"Business with given id: {businessId} not found");
        }

        var invoice = await _dbContext
            .Invoices
            .Where(i => i.BusinessId == businessId)
            .Include(i => i.Products)
            .Include(i => i.Recipient)
            .Include(i => i.Issuer)
            .FirstOrDefaultAsync(i => i.Id == invoiceId);

        if (invoice == null)
        {
            throw new NotFoundException($"Invoice with given id: {invoiceId} not found");
        }

        var invoiceDto = _mapper.Map<InvoiceDto>(invoice);
        
        return invoiceDto;
    }
}
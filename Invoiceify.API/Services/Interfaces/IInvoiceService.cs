using Invoiceify.API.Dtos.InvoiceDtos;

namespace Invoiceify.API.Services.Interfaces;

public interface IInvoiceService
{
    Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync(int businessId);
    Task<InvoiceDto> GetInvoiceByIdAsync(int invoiceId, int businessId);
}
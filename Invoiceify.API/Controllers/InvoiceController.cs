using Invoiceify.API.Dtos.InvoiceDtos;
using Invoiceify.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Invoiceify.API.Controllers;

[Route("api/businesses/{businessId}/invoices")]
[ApiController]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceService _invoiceService;

    public InvoiceController(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    /// <summary>
    /// Returns all available invoices assigned to given business
    /// </summary>
    /// <param name="businessId">Id of a business</param>
    /// <returns>List of invoices</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetAllAsync([FromRoute]int businessId)
    {
        var invoices = await _invoiceService.GetAllInvoicesAsync(businessId);
    
        return invoices != null ? Ok(invoices) : NotFound();
    }
    
    /// <summary>
    /// Returns the invoice with the given id and assigned to given business
    /// </summary>
    /// <param name="businessId">Id of a business</param>
    /// <param name="invoiceId">Id of a invoice</param>
    /// <returns>Invoice</returns>
    [HttpGet("{invoiceId}")]
    public async Task<ActionResult<InvoiceDto>> GetByIdAsync([FromRoute]int businessId, [FromRoute] int invoiceId)
    {
        var invoice = await _invoiceService.GetInvoiceByIdAsync(invoiceId, businessId);
    
        return invoice != null ? Ok(invoice) : NotFound();
    }
}
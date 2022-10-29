using Invoiceify.API.Dtos.InvoiceDtos;
using Invoiceify.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Invoiceify.API.Controllers;

[Route("api/businesses")]
[ApiController]
public class BusinessController : ControllerBase
{
    private readonly IBusinessService _businessService;

    public BusinessController(IBusinessService businessService)
    {
        _businessService = businessService;
    }
    
    /// <summary>
    /// Creates and saves a business to the database based on the given parameters
    /// </summary>
    /// <param name="createBusinessDto">Parameters of the created business</param>
    /// <returns>Status created (201)</returns>
    [HttpPost("new")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateBusinessDto createBusinessDto)
    {
        var businessId = await _businessService.CreateBusinessAsync(createBusinessDto);

        return Created($"/api/businesses/{businessId}", null);
    }

    /// <summary>
    /// Deletes the business with the specified id
    /// </summary>
    /// <param name="id">Id of a business</param>
    /// <returns>Status no content (204)</returns>
    [HttpDelete("{id}/delete")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        await _businessService.DeleteBusinessAsync(id);

        return NoContent();
    }

    /// <summary>
    /// Updates the parameters of the selected business to the specified parameters
    /// </summary>
    /// <param name="id">Id of a business</param>
    /// <param name="updateBusinessDto">Parameters to which the business parameters will be changed</param>
    /// <returns>Status ok (200)</returns>
    [HttpPut("{id}/update")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateBusinessDto updateBusinessDto)
    {
        await _businessService.UpdateBusiness(id, updateBusinessDto);

        return Ok();
    }
    
    /// <summary>
    /// Returns all available business basic information(name, email and isOrganization) in the database
    /// </summary>
    /// <returns>List of business basic information</returns>
    [HttpGet ("inforamtion")]
    public async Task<ActionResult<IEnumerable<BusinessDto>>> GetAllBasicInformationAsync()
    {
        var businessBasicInformation = await _businessService.GetAllBusinessBasicInformationAsync();
    
        return businessBasicInformation != null ? Ok(businessBasicInformation) : NotFound();
    }
    
    /// <summary>
    /// Returns all available businesses
    /// </summary>
    /// <returns>List of businesses</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BusinessDto>>> GetAllAsync()
    {
        var businesses = await _businessService.GetAllBusinessesAsync();
    
        return businesses != null ? Ok(businesses) : NotFound();
    }
    
    /// <summary>
    /// Returns the business with the given id
    /// </summary>
    /// <param name="id">Id of a business</param>
    /// <returns>Business</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<BusinessDto>> GetByIdAsync([FromRoute] int id)
    {
        var business = await _businessService.GetBusinessByIdAsync(id);

        return business != null ? Ok(business) : NotFound();
    }
}
using Invoiceify.API.Dtos.CustomerDtos;
using Invoiceify.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Invoiceify.API.Controllers;

[Route("api/businesses/{businessId}/customers")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    
    /// <summary>
    /// Creates and saves a customer to the database based on the given parameters
    /// </summary>
    /// <param name="businessId">Id of a business</param>
    /// <param name="createCustomerDto">Parameters of the created customer</param>
    /// <returns>Status created (201) with the path to the created customer</returns>
    [HttpPost("new")]
    public async Task<IActionResult> CreateAsync([FromRoute]int businessId, [FromBody]CreateCustomerDto createCustomerDto)
    {
        var customerId = await _customerService.CreateCustomerAsync(businessId, createCustomerDto);

        return Created($"/api/{businessId}/customer/{customerId}", null);
    }
    
    /// <summary>
    /// Deletes the customer with the specified id
    /// </summary>
    /// <param name="businessId">Id of a business</param>
    /// <param name="customerId">Id of a customer</param>
    /// <returns>Status no content (204)</returns>
    [HttpDelete("delete/{customerId}")]
    public async Task<IActionResult> DeleteAsync([FromRoute]int businessId, [FromRoute]int customerId)
    {
        await _customerService.DeleteCustomerAsync(businessId, customerId);
    
        return NoContent();
    }

    /// <summary>
    /// Updates the parameters of the selected customer to the given parameters
    /// </summary>
    /// <param name="businessId">Id of a business</param>
    /// <param name="customerId">Id of a customer</param>
    /// <param name="updateCustomerDto">Parameters to which the customer parameters will be changed</param>
    /// <returns>Status ok (200)</returns>
    [HttpPut("update/{customerId}")]
    public async Task<IActionResult> UpdateAsync([FromRoute]int businessId, [FromRoute] int customerId, [FromBody]UpdateCustomerDto updateCustomerDto)
    {
        await _customerService.UpdateCustomerAsync(businessId, customerId, updateCustomerDto);
    
        return Ok();
    }
    
    /// <summary>
    /// Returns all available customers assigned to given business
    /// </summary>
    /// <param name="businessId">Id of a business</param>
    /// <returns>List of customers</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllAsync([FromRoute]int businessId)
    {
        var customers = await _customerService.GetAllCustomersAsync(businessId);
    
        return customers != null ? Ok(customers) : NotFound();
    }
    
    /// <summary>
    /// Returns the customer with the given id assigned to given business
    /// </summary>
    /// <param name="businessId">Id of a business</param>
    /// <param name="customerId">Id of a customer</param>
    /// <returns>Customer</returns>
    [HttpGet("{customerId}")]
    public async Task<ActionResult<CustomerDto>> GetByIdAsync([FromRoute]int businessId, [FromRoute] int customerId)
    {
        var customer = await _customerService.GetCustomerByIdAsync(customerId, businessId);
    
        return customer != null ? Ok(customer) : NotFound();
    }
}
using Invoiceify.API.Dtos.CustomerDtos;

namespace Invoiceify.API.Services.Interfaces;

public interface ICustomerService
{
    Task<int> CreateCustomerAsync(int businessId, CreateCustomerDto createCustomerDto);
    Task DeleteCustomerAsync(int businessId, int customerId);
    Task UpdateCustomerAsync(int businessId, int customerId, UpdateCustomerDto updateCustomerDto);
    Task<IEnumerable<CustomerDto>> GetAllCustomersAsync(int businessId);
    Task<CustomerDto> GetCustomerByIdAsync(int customerId, int businessId);
}
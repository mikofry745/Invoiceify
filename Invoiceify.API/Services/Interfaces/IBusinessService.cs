using Invoiceify.API.Dtos.InvoiceDtos;

namespace Invoiceify.API.Services.Interfaces;

public interface IBusinessService
{
    Task<int> CreateBusinessAsync(CreateBusinessDto createBusinessDto);
    Task DeleteBusinessAsync(int restaurantId);
    Task UpdateBusiness(int restaurantId, UpdateBusinessDto updateBusinessDto);
    Task<IEnumerable<BusinessBasicInformationDto>> GetAllBusinessBasicInformationAsync();
    Task<IEnumerable<BusinessDto>> GetAllBusinessesAsync();
    Task<BusinessDto> GetBusinessByIdAsync(int id);
}
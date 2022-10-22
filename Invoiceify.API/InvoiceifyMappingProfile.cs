using AutoMapper;
using Invoiceify.API.Dtos.InvoiceDtos;
using Invoiceify.API.Dtos.ProductDtos;
using Invoiceify.Entities.Entities;

namespace Invoiceify.API;

public class InvoiceifyMappingProfile: Profile
{
    public InvoiceifyMappingProfile()
    {
        //Business dtos mapping profiles
        CreateMap<Business, BusinessDto>()
            .ForMember(dto => dto.Street, c => 
                c.MapFrom(b => b.Profile!.Street))
            .ForMember(dto => dto.City, c => 
                c.MapFrom(b => b.Profile!.City))
            .ForMember(dto => dto.PostalCode, c =>
                c.MapFrom(b => b.Profile!.PostalCode))
            .ForMember(dto => dto.TaxIdentificationNumber, c => 
                c.MapFrom(b => b.Profile!.TaxIdentificationNumber))
            .ForMember(dto => dto.EmailAddress, c => 
                c.MapFrom(b => b.Profile!.EmailAddress))
            .ForMember(dto => dto.Name, c => 
                c.MapFrom(b => b.Profile!.Name))
            .ForMember(dto => dto.PhoneNumber, c => 
                c.MapFrom(b => b.Profile!.PhoneNumber))
            .ForMember(dto => dto.Country, c =>
                c.MapFrom(b => b.Profile!.Country));

        CreateMap<Business, BusinessBasicInformationDto>()
            .ForMember(dto => dto.Name, c =>
                c.MapFrom(b => b.Profile!.Name))
            .ForMember(dto => dto.EmailAddress, c =>
                c.MapFrom(b => b.Profile!.EmailAddress));

        CreateMap<CreateBusinessDto, Business>()
            .ForMember(b => b.Profile, c => 
                c.MapFrom(dto => new BusinessProfile()
                {
                    Name = dto.Name,
                    City = dto.City,
                    Street = dto.Street,
                    PostalCode = dto.PostalCode,
                    EmailAddress = dto.EmailAddress,
                    TaxIdentificationNumber = dto.TaxIdentificationNumber,
                    Country = "",
                    PhoneNumber = ""
                }));


        //Product dtos mapping profiles
        CreateMap<Product, ProductDto>();
    }
}
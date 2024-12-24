using AutoMapper;

using Grand.Domain.Stores;
using Grand.Infrastructure.Mapper;
using Grand.Module.Api.DTOs.Common;

namespace Grand.Module.Api.Infrastructure.Mapper.Profiles;

public class StoreProfile : Profile, IAutoMapperProfile
{
    //Profile for store
    public StoreProfile()
    {
        CreateMap<StoreDto, Store>()
            
            
            .ForMember(dest => dest.SecureUrl, mo => mo.Ignore())
            .ForMember(dest => dest.Domains, mo => mo.Ignore())
            .ForMember(dest => dest.DefaultLanguageId, mo => mo.Ignore())
            .ForMember(dest => dest.DefaultCountryId, mo => mo.Ignore())
            .ForMember(dest => dest.DefaultCurrencyId, mo => mo.Ignore())
            .ForMember(dest => dest.CompanyVat, mo => mo.Ignore())
            .ForMember(dest => dest.CompanyHours, mo => mo.Ignore())
            .ForMember(dest => dest.BankAccount, mo => mo.Ignore())
            .ForMember(dest => dest.Locales, mo => mo.Ignore())
            
            .ForMember(dest => dest.CreatedOnUtc, mo => mo.Ignore())
            .ForMember(dest => dest.UpdatedOnUtc, mo => mo.Ignore())
            .ForMember(dest => dest.CreatedBy, mo => mo.Ignore())
            .ForMember(dest => dest.UpdatedBy, mo => mo.Ignore())
            .ForMember(dest => dest.UserFields, mo => mo.Ignore());

        CreateMap<Store, StoreDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)) //This is store name
            .ForMember(dest => dest.Shortcut, opt => opt.MapFrom(src => src.Shortcut)) //This is store name
            .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url))
            .ForMember(dest => dest.SslEnabled, opt => opt.MapFrom(src => src.SslEnabled))
            .ForMember(dest => dest.DefaultWarehouseId, opt => opt.MapFrom(src => src.DefaultWarehouseId))
            .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyName))
            .ForMember(dest => dest.CompanyPhoneNumber, opt => opt.MapFrom(src => src.CompanyPhoneNumber))
            .ForMember(dest => dest.CompanyEmail, opt => opt.MapFrom(src => src.CompanyEmail))
            .ForMember(dest => dest.CompanyAddress, opt => opt.MapFrom(src => src.CompanyAddress))
            .ForMember(dest => dest.DisplayOrder, opt => opt.MapFrom(src => src.DisplayOrder))
            .ForMember(dest => dest.CreatedOnUtc, opt => opt.MapFrom(src => src.CreatedOnUtc))
            .ForMember(dest => dest.UpdatedOnUtc, opt => opt.MapFrom(src => src.UpdatedOnUtc))
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
            .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy));
    }

    public int Order => 0;
}


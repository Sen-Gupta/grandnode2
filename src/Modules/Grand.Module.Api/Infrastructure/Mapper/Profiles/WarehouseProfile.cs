using AutoMapper;

using Grand.Domain.Shipping;
using Grand.Infrastructure.Mapper;
using Grand.Module.Api.DTOs.Shipping;

namespace Grand.Module.Api.Infrastructure.Mapper.Profiles;

public class WarehouseProfile : Profile, IAutoMapperProfile
{
    public WarehouseProfile()
    {
        //Ignore all fields that are not in dto
       //Write the code below

        CreateMap<WarehouseDto, Warehouse>()
            .ForMember(dest => dest.Latitude, mo => mo.Ignore())
            .ForMember(dest => dest.Longitude, mo => mo.Ignore())
            .ForMember(dest => dest.Address, mo => mo.Ignore())
            .ForMember(dest => dest.DisplayOrder, mo => mo.Ignore())
            .ForMember(dest => dest.CreatedOnUtc, mo => mo.Ignore())
            .ForMember(dest => dest.UpdatedOnUtc, mo => mo.Ignore())
            .ForMember(dest => dest.UserFields, mo => mo.Ignore())
            .ForMember(dest => dest.Address, mo => mo.Ignore()); 


        CreateMap<Warehouse, WarehouseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.AdminComment, opt => opt.MapFrom(src => src.AdminComment))
            .ForMember(dest => dest.CreatedOnUtc, opt => opt.MapFrom(src => src.CreatedOnUtc))
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
            .ForMember(dest => dest.UpdatedOnUtc, opt => opt.MapFrom(src => src.UpdatedOnUtc))
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UpdatedBy));
    }

    public int Order => 1;
}
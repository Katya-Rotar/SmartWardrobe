using BLL.DTO;
using BLL.DTO.Category;
using BLL.DTO.Style;
using BLL.DTO.TemperatureSuitability;
using BLL.DTO.Type;
using BLL.Helpers.Mapping;
using DAL.Entities;
using DAL.Helpers;
using Profile = AutoMapper.Profile;
using Type = DAL.Entities.Type;

namespace BLL;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap(typeof(PagedList<>), typeof(PagedList<>))
            .ConvertUsing(typeof(PagedListConverter<,>));
        
        CreateMap<ClothingItem, ClothingItemDto>().ReverseMap();
        CreateMap<CreateClothingItemDto, ClothingItem>().ReverseMap();
        CreateMap<ClothingItem, ClothingItemAllDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
            .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.TypeName))
            .ForMember(dest => dest.TemperatureSuitabilityName, opt => opt.MapFrom(src => src.TemperatureSuitability.TemperatureSuitabilityName))
            .ForMember(dest => dest.StyleNames, opt => opt.MapFrom(src => src.Styles.Select(s => s.Style.StyleName)))
            .ForMember(dest => dest.SeasonNames, opt => opt.MapFrom(src => src.Seasons.Select(s => s.Season.SeasonName)));
        
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Type, TypeDto>().ReverseMap();
        CreateMap<TemperatureSuitability, TemperatureSuitabilityDto>().ReverseMap();
        CreateMap<Style, StyleDto>().ReverseMap();
    }
}
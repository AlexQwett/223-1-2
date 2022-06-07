using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL
{
    internal class BLLProfile : Profile
    {
        public BLLProfile()
        {
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<Hotel, HotelDTO>()
                .ForMember(dto => dto.CityId, m => m.MapFrom(h => h.CityId))
                .ForMember(dto => dto.City, m => m.MapFrom(h => h.City))
                .ReverseMap();
            CreateMap<Tour, TourDTO>()
                .ForMember(dto => dto.HotelId, m => m.MapFrom(t => t.HotelId))
                .ForMember(dto => dto.Hotel, m => m.MapFrom(t => t.Hotel))
                .ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<FilteredTour, FilteredTourDTO>()
                .ForMember(dto => dto.FilteredTourId, m => m.MapFrom(ft => ft.FilteredTourId))
                .ForMember(dto => dto.TourId, m => m.MapFrom(t => t.TourId))
                .ForMember(dto => dto.CategoryId, m => m.MapFrom(c => c.CategoryId))
                .ForMember(dto => dto.Tour, m => m.MapFrom(t => t.Tour))
                .ForMember(dto => dto.Category, m => m.MapFrom(t => t.Category))
                .ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<CountryCity, CountryCityDTO>()
                .ForMember(dto => dto.CityId, m => m.MapFrom(cc => cc.CityId))
                .ForMember(dto => dto.CountryId, m => m.MapFrom(cc => cc.CountryId))
                .ForMember(dto => dto.City, m => m.MapFrom(cc => cc.City))
                .ForMember(dto => dto.Country, m => m.MapFrom(cc => cc.Country))
                .ReverseMap();
            CreateMap<Booking, BookingDTO>().ReverseMap();
        }
    }
}

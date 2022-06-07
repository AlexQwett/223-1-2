using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Entities;

namespace BLL.Services
{
    public class CountryCityService
    {

        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CountryCityService()
        {
            _unitOfWork = UnitOfWork.Unit;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<BLLProfile>()).CreateMapper();
        }

        public void AddCity(CityDTO city)
        {
            _unitOfWork.Cities.Add(_mapper.Map<City>(city));
            _unitOfWork.Save();
        }

        public void AddCountry(CountryDTO country)
        {
            _unitOfWork.Countries.Add(_mapper.Map<Country>(country));
            _unitOfWork.Save();
        }

        public void Add(int cityId, int countryId)
        {
            var country = _unitOfWork.Countries.Get(countryId);
            var city = _unitOfWork.Cities.Get(cityId);
            if (country is null || city is null)
                return;
            _unitOfWork.CountriesCities.Add(new CountryCity
            {
                CountryId = country.CountryId,
                CityId = city.CityId,
                Country = country,
                City = city
            });
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.CountriesCities.Delete(id);
            _unitOfWork.Save();
        }

        public void DeleteCity(int id)
        {
            _unitOfWork.Cities.Delete(id);
            _unitOfWork.Save();
        }

        public void DeleteCountry(int id)
        {
            _unitOfWork.Countries.Delete(id);
            _unitOfWork.Save();
        }

        public List<CountryDTO> GetCountries()
        {
            var countries = _unitOfWork.Countries.GetAll();
            var dtos = new List<CountryDTO>();
            foreach (var item in countries)
                dtos.Add(_mapper.Map<CountryDTO>(item));
            return dtos;
        }

        public List<CityDTO> GetCities()
        {
            var cities = _unitOfWork.Cities.GetAll();
            var dtos = new List<CityDTO>();
            foreach (var item in cities)
                dtos.Add(_mapper.Map<CityDTO>(item));
            return dtos;
        }

        public List<CountryCityDTO> GetAll()
        {
            var cc = _unitOfWork.CountriesCities.GetAll();
            var dtos = new List<CountryCityDTO>();
            foreach (var item in cc)
                dtos.Add(_mapper.Map<CountryCityDTO>(item));
            return dtos;
        }

    }
}

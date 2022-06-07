using AutoMapper;
using BLL.DTOs;
using DAL;

namespace BLL.Services
{
    public class CitiesService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CitiesService()
        {
            _unitOfWork = UnitOfWork.Unit;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<BLLProfile>()).CreateMapper();
        }

        public IEnumerable<CityDTO> GetAll()
        {
            var tours = _unitOfWork.Cities.GetAll();
            var cities = new List<CityDTO>();
            foreach (var item in tours)
                cities.Add(_mapper.Map<CityDTO>(item));
            return cities;
        }

        public CityDTO Get(string city)
        {
            return _mapper.Map<CityDTO>(_unitOfWork.Cities.GetAll().FirstOrDefault(x => x.CityName.Contains(city)));
        }

        public CityDTO AddAndGet(string city)
        {
            var existingCity = _unitOfWork.Cities.GetAll().FirstOrDefault(x => x.CityName.Contains(city));
            if (existingCity is null)
            {
                _unitOfWork.Cities.Add(new DAL.Entities.City
                {
                    CityName = city
                });
                _unitOfWork.Save();
            }
            return _mapper.Map<CityDTO>(_unitOfWork.Cities.GetAll().FirstOrDefault(x => x.CityName.Contains(city)));  
        }
    }
}

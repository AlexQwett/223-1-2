using AutoMapper;
using BLL.DTOs;
using BLL.Exceptions;
using DAL;
using DAL.Entities;

namespace BLL.Services
{
    public class ToursService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ToursService()
        {
            _unitOfWork = UnitOfWork.Unit;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<BLLProfile>()).CreateMapper();
        }

        public void Add(TourDTO tour)
        {
            _unitOfWork.Tours.Add(_mapper.Map<Tour>(tour));
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.Tours.Delete(id);
            _unitOfWork.Save();
        }

        public TourDTO Get(int id)
        {
            return _mapper.Map<TourDTO>(_unitOfWork.Tours.Get(id));
        }

        public TourDTO Get(decimal price, string hotel)
        {
            return _mapper.Map<TourDTO>(_unitOfWork.Tours.GetAll().FirstOrDefault(x => x.Price == price && x.Hotel.HotelTitle.Contains(hotel)));
        }

        public List<TourDTO> GetAll()
        {
            var tours = _unitOfWork.Tours.GetAll();
            var dtos = new List<TourDTO>();
            foreach (var tour in tours)
                dtos.Add(_mapper.Map<TourDTO>(tour));
            return dtos;
        }
    }
}
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Entities;

namespace BLL.Services
{
    public class HotelsService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public HotelsService()
        {
            _unitOfWork = UnitOfWork.Unit;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<BLLProfile>()).CreateMapper();
        }
        public List<HotelDTO> GetAll()
        {
            var hotels = _unitOfWork.Hotels.GetAll();
            var dtos = new List<HotelDTO>();
            foreach (var hotel in hotels)
                dtos.Add(_mapper.Map<HotelDTO>(hotel));
            return dtos;
        }

        public HotelDTO Get(string hotel)
        {
            return _mapper.Map<HotelDTO>(_unitOfWork.Hotels.GetAll().FirstOrDefault(x => x.HotelTitle.Contains(hotel)));
        }

        public HotelDTO Get(int id)
        {
            return _mapper.Map<HotelDTO>(_unitOfWork.Hotels.Get(id));
        }

        public void Add(HotelDTO hotelDTO)
        {
            _unitOfWork.Hotels.Add(_mapper.Map<Hotel>(hotelDTO));
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.Hotels.Delete(id);
            _unitOfWork.Save();
        }
    }
}

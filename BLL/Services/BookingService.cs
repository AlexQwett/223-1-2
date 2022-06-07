using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Entities;

namespace BLL.Services
{
    public class BookingService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BookingService()
        {
            _unitOfWork = UnitOfWork.Unit;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<BLLProfile>()).CreateMapper();
        }
        public void Add(UserDTO userDto, TourDTO tourDto)
        {
            _unitOfWork.Booking.Add(new Booking
            {
                TourId = tourDto.TourId,
                UserId = userDto.UserId,
                Tour = _mapper.Map<Tour>(userDto),
                User = _mapper.Map<User>(userDto)
            });
            _unitOfWork.Save();
        }

        public void Remove(int id)
        {
            _unitOfWork.Booking.Delete(id);
            _unitOfWork.Save();
        }

        public List<BookingDTO> GetAll(UserDTO user)
        {
            var bookings = _unitOfWork.Booking.GetAll();
            var dtos = new List<BookingDTO>();
            foreach (var item in bookings)
                dtos.Add(_mapper.Map<BookingDTO>(item));
            return dtos.Where(x => x.UserId == user.UserId).ToList();
        }
    }
}

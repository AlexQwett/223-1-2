using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Entities;
using DAL.Exceptions;

namespace BLL.Services
{
    public enum DefaultCategory
    {
        Default,
        Hot,
        NotHot
    }

    public class FilteredToursService
    {

        private const string defaultCategory = "Hot";
        private const string defaultCity = "Alanya";
        private const int defaultRating = 5;

        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FilteredToursService()
        {
            _unitOfWork = UnitOfWork.Unit;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<BLLProfile>()).CreateMapper();
        }

        public void Add(FilteredTourDTO filteredTour)
        {
            _unitOfWork.FilteredTours.Add(_mapper.Map<FilteredTour>(filteredTour));
            _unitOfWork.Save();
        }

        public void Associate(int tourId, int categoryId)
        {
            var tour = _unitOfWork.Tours.Get(tourId);
            var category = _unitOfWork.Categories.Get(categoryId);

            if(tour is not null && category is not null)
            {
                try
                {
                    _unitOfWork.FilteredTours.Add(new FilteredTour
                    {
                        TourId = tour.TourId,
                        Tour = _mapper.Map<Tour>(tour),
                        CategoryId = category.CategoryId,
                        Category = _mapper.Map<Category>(category)
                    });
                }
                catch (DAL.Exceptions.NotFoundException)
                {
                    throw new Exceptions.FilteredTourException();
                }

                _unitOfWork.Save();
            }
            else throw new Exceptions.FilteredTourException();
        }

        public FilteredTourDTO Get(int id)
        {
            return _mapper.Map<FilteredTourDTO>(_unitOfWork.FilteredTours.Get(id));
        }

        public List<FilteredTourDTO> GetAll(DefaultCategory category)
        {
            var tours = _unitOfWork.FilteredTours.GetAll();
            var dtos = new List<FilteredTourDTO>();
            foreach (var tour in tours)
                dtos.Add(_mapper.Map<FilteredTourDTO>(tour));

            if (category == DefaultCategory.Hot)
                return dtos.Where(x => x.Category.Title == defaultCategory).ToList();
            if (category == DefaultCategory.NotHot)
                return dtos.Where(x => x.Category.Title != defaultCategory).ToList();
            return dtos;
        }

        public List<FilteredTourDTO> GetAllBy
            (string category = defaultCategory, string city = defaultCity, byte rating = defaultRating)
        {
            var tours = _unitOfWork.FilteredTours.GetAll();
            var dtos = new List<FilteredTourDTO>();

            foreach (var tour in tours)
                dtos.Add(_mapper.Map<FilteredTourDTO>(tour));
            return dtos.Where(x => x.Category.Title == category)
                .Where(x => x.Tour.Hotel.City.CityName == city)
                .Where(x => x.Tour.Hotel.Stars == rating)
                .ToList();
        }

        public void Delete(int id)
        {
            _unitOfWork.FilteredTours.Delete(id);
            _unitOfWork.Save();
        }
    }
}

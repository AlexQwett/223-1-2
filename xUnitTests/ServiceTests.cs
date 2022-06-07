
using BLL.DTOs;
using BLL.Services;
using DAL.Entities;
using Xunit;

namespace xUnitTests
{
    public class ServiceTests
    {
        private readonly CitiesService _serviceCity;
        private readonly HotelsService _serviceHotel;
        private readonly ToursService _serviceTours;
        private readonly FilteredToursService _serviceFilteredTours;
        private readonly UserService _serviceUser;

        public ServiceTests()
        {
            _serviceCity = new CitiesService();
            _serviceHotel = new HotelsService(); 
            _serviceTours = new ToursService();
            _serviceFilteredTours = new FilteredToursService();
            _serviceUser = new UserService();
        }

        [Fact]
        public void GetCity_ShouldReturnCity_WhenCityExists()
        {
            // Arrange
            var cityName = "Kiyv";

            // Act
            var city = _serviceCity.Get(cityName);

            // Assert
            Assert.Contains(cityName, city.CityName);
        }

        [Fact]
        public void GetAllCity_ShouldNotBeEmpty()
        {
            // Act
            var cities = _serviceCity.GetAll();

            //Assert
            Assert.NotEmpty(cities);
        }


        [Fact]
        public void GetHotel_ShouldReturnHotel_WhenHotelExists()
        {
            // Arrange
            var hotelTitle = "Holiday Village";

            // Act
            var hotel = _serviceHotel.Get(hotelTitle);

            // Assert
            Assert.Contains(hotelTitle, hotel.HotelTitle);
        }

        [Fact]
        public void GetAllHotels_ShouldNotBeEmpty()
        {
            // Act
            var hotels = _serviceHotel.GetAll();

            //Assert
            Assert.NotEmpty(hotels);
        }

        [Fact]
        public void GetTours_ShouldReturnTour_WhenTourExists()
        {
            // Arrange
            var tourId = 7;

            // Act
            var tour = _serviceTours.Get(tourId);

            // Assert
            Assert.Equal(tourId, tour.TourId);
        }

        [Fact]
        public void GetAllTours_ShouldNotBeEmpty()
        {
            // Act
            var tours = _serviceTours.GetAll();

            //Assert
            Assert.NotEmpty(tours);
        }

        [Fact]
        public void GetFilteredTours_ShouldReturnFilteredTour_WhenFilteredTourExists()
        {
            // Arrange
            var tourId = 3;

            // Act
            var tour = _serviceFilteredTours.Get(tourId);

            // Assert
            Assert.Equal(tourId, tour.FilteredTourId);
        }

        [Fact]
        public void GetAllFilteredTours_ShouldNotBeEmpty()
        {
            //Arrange
            var option = DefaultCategory.Default;

            // Act
            var tours = _serviceFilteredTours.GetAll(option);

            //Assert
            Assert.NotEmpty(tours);
        }


        [Fact]
        public void GetUser_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var email = "vanya@gmail.com";
            var password = "18let";
            // Act
            var user = _serviceUser.Get(email, password);

            // Assert
            Assert.Contains(email, user.Login);
            Assert.Contains(password, user.Password);
        }

        [Fact]
        public void GetAllUsers_ShouldNotBeEmpty()
        {
            //Arrange
            var option = DefaultCategory.Default;

            // Act
            var tours = _serviceFilteredTours.GetAll(option);

            //Assert
            Assert.NotEmpty(tours);
        }
    }
}
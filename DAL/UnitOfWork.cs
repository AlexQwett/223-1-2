using DAL.Entities;
using DAL.Repositories;

namespace DAL
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly TravelAgencyContext _context;
        private static UnitOfWork? _unitOfWork;

        private IRepository<FilteredTour>? _filteredTours;
        private IRepository<Tour>? _tours;
        private IRepository<Booking>? _booking;
        private IRepository<Hotel>? _hotels;
        private IRepository<User>? _users;
        private IRepository<Category>? _categories;
        private IRepository<City>? _cities;
        private IRepository<Country>? _countries;
        private IRepository<CountryCity>? _countriesCities;

        private UnitOfWork()
        {
            _context = new TravelAgencyContext();
        }

        public static UnitOfWork Unit
        {
            get
            {
                if (_unitOfWork is null)
                    _unitOfWork = new UnitOfWork();
                return _unitOfWork;
            }
        }

        public IRepository<FilteredTour> FilteredTours
        {
            get
            {
                if (_filteredTours is null)
                    _filteredTours = new FilteredTourRepository(_context);
                return _filteredTours;
            }
        }

        public IRepository<Tour> Tours
        {
            get
            {
                if (_tours is null)
                    _tours = new TourRepository(_context);
                return _tours;
            }
        }

        public IRepository<Booking> Booking
        {
            get
            {
                if (_booking is null)
                    _booking = new BookingRepository(_context);
                return _booking;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (_categories is null)
                    _categories = new CategoryRepository(_context);
                return _categories;
            }
        }

        public IRepository<Hotel> Hotels
        {
            get
            {
                if (_hotels is null)
                    _hotels = new HotelRepository(_context);
                return _hotels;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (_users is null)
                    _users = new UserRepository(_context);
                return _users;
            }
        }

        public IRepository<City> Cities
        {
            get
            {
                if (_cities is null)
                    _cities = new CityRepository(_context);
                return _cities;
            }
        }
        public IRepository<Country> Countries
        {
            get
            {
                if (_countries is null)
                    _countries = new CountryRepository(_context);
                return _countries;
            }
        }

        public IRepository<CountryCity> CountriesCities
        {
            get
            {
                if (_countriesCities is null)
                    _countriesCities = new CountryCityRepository(_context);
                return _countriesCities;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
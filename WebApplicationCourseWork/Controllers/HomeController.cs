using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationCourseWork.Models;

namespace WebApplicationCourseWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly Service service = new Service();

        private readonly UserService _userService; 
        private readonly CategoriesService _categoriesService;
        private readonly CitiesService _citiesService;
        private readonly FilteredToursService _fToursService;
        private readonly ToursService _toursService;
        private readonly HotelsService _hotelsService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _userService = new UserService();
            _categoriesService = new CategoriesService();
            _citiesService = new CitiesService();
            _toursService = new ToursService();
            _fToursService = new FilteredToursService();
            _hotelsService = new HotelsService();
        }

        [HttpGet]
        [ActionName("Index")]
        public IActionResult Index(UserDTO? user = null)
        {
            int[] starsArray = { 1, 2, 3, 4, 5 };
            List<int> Stars = starsArray.ToList<int>();

            ViewBag.Categories = _categoriesService.GetAll();
            ViewBag.Towns = _citiesService.GetAll();
            ViewBag.Stars = Stars;
            ViewBag.HotTours = _fToursService.GetAll(DefaultCategory.Hot);
            ViewBag.DefaultTours = _fToursService.GetAll(DefaultCategory.NotHot);
            ViewBag.User = user;       

            return View();
        }

        [HttpGet]
        [ActionName("Find")]
        public IActionResult Find(string category, string town, int hotelStars)
        {
            int[] starsArray = { 1, 2, 3, 4, 5 };
            List<int> Stars = starsArray.ToList<int>();

            ViewBag.HotTours = new List<FilteredTourDTO>();
            ViewBag.Categories = _categoriesService.GetAll();
            ViewBag.Towns = _citiesService.GetAll();
            ViewBag.Stars = Stars;
            ViewBag.User = new UserDTO();

            ViewBag.DefaultTours = _fToursService.GetAllBy(category, town, Convert.ToByte(hotelStars));

            return View("~/Views/Home/Index.cshtml");
        }

        [HttpGet]
        [ActionName("Tour")]
        public IActionResult GetTour(int id)
        {
            FilteredTourDTO tour = _fToursService.Get(id);

            ViewBag.FilteredTour = tour;
            ViewBag.TourId = id;

            return View("~/Views/Home/TourPage.cshtml");
        }

        [HttpGet]
        [ActionName("ReserveTour")]
        public IActionResult GetReserveTour(int id)
        {
            ViewBag.Price = _fToursService.Get(id).Tour.Price;
            return View("~/Views/Home/ReserveTour.cshtml");

        }

        [HttpPost]
        [ActionName("ReserveTour")]
        public IActionResult ReserveTour(int tourID, string firstName, string lastName, string phone, string email)
        {
            if (firstName is not null)
            {
                ViewBag.Message = "Your order has been accepted, please wait for a call from our administrator to confirm";
                return View("~/Views/Home/ConfirmMessage.cshtml");
            }

            ViewBag.Price = _fToursService.Get(tourID).Tour.Price;
            return View("~/Views/Home/ReserveTour.cshtml");

        }

        [HttpGet]
        [ActionName("Add")]
        public IActionResult GetAddTour()
        {
            int[] starsArray = { 1, 2, 3, 4, 5 };
            List<int> Stars = starsArray.ToList<int>();

            ViewBag.Categories = _categoriesService.GetAll();
            ViewBag.Towns = _citiesService.GetAll();
            ViewBag.Stars = Stars;

            return View("~/Views/Home/AddTour.cshtml");
        }

        [HttpPost]
        [ActionName("Add")]
        public IActionResult AddTour(string categoryTitle, string townTitle, string hotelTitle, int hotelStars, int price)
        {
            var hotel = new HotelDTO
            {
                Stars = Convert.ToByte(hotelStars),
                HotelTitle = hotelTitle,
                City = _citiesService.AddAndGet(townTitle)
            };

            _hotelsService.Add(hotel);
            hotel = _hotelsService.Get(hotelTitle);

            var tour = new TourDTO
            {
                Price = price,
                Hotel = hotel
            };

            _toursService.Add(tour);
            tour = _toursService.Get(price, hotelTitle);

            var filteredTour = new FilteredTourDTO
            {
                Category = _categoriesService.Get(categoryTitle),
                Tour = tour
            };

            _fToursService.Add(filteredTour);

            ViewBag.Message = "Tour successfully added";
            return View("~/Views/Home/ConfirmMessage.cshtml");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult GetDeleteTour()
        {
            int[] starsArray = { 1, 2, 3, 4, 5 };
            List<int> Stars = starsArray.ToList<int>();

            ViewBag.Categories = _categoriesService.GetAll();
            ViewBag.Towns = _citiesService.GetAll();
            ViewBag.Stars = Stars;
            ViewBag.Tours = _fToursService.GetAll(DefaultCategory.Default);

            return View("~/Views/Home/DeleteTour.cshtml");
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            _fToursService.Delete(id);
            ViewBag.Message = "Tour successfully deleted";
            return View("~/Views/Home/ConfirmMessage.cshtml");
        }

        [HttpGet]
        [ActionName("Registration")]
        public IActionResult GetRegistry()
        {
            return View("~/Views/Home/Registry.cshtml");
        }

        [HttpPost]
        [ActionName("Registration")]
        public IActionResult Registry(UserDTO user)
        {
            _userService.Add(user);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("LogIn")]
        public IActionResult GetLogIn()
        {
            return View("~/Views/Home/LogIn.cshtml");
        }

        [HttpPost]
        [ActionName("LogIn")]
        public IActionResult LogIn(string login, string password)
        {
            UserDTO user = _userService.Get(login, password);

            return RedirectToAction("Index", user);
        }

        [HttpGet]
        [ActionName("LogOut")]
        public IActionResult LogOut()
        {
            return RedirectToAction("Index", new UserDTO());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
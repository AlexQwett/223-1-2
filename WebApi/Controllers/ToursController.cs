using BLL.DTOs;
using BLL.Exceptions;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private readonly HotelsService _hotelService;
        private readonly ToursService _tourService;
        public ToursController()
        {
            _hotelService = new HotelsService();
            _tourService = new ToursService();
        }

        [HttpGet]
        public IEnumerable<TourDTO> Get()
        {
            return _tourService.GetAll();   
        }

        // POST api/<ToursController>
        [HttpPost]
        public void Post(int hotelId, decimal price)
        {
            _tourService.Add(new TourDTO
            {
                HotelId = hotelId,
                Hotel = _hotelService.Get(hotelId),
                Price = price
            });
        }

        // DELETE api/<ToursController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _tourService.Delete(id);
        }
    }
}

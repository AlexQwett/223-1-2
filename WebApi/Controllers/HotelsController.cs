using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly HotelsService _hotelService;
        public HotelsController()
        {
            _hotelService = new HotelsService();
        }

        // GET: api/<HotelsController>
        [HttpGet]
        public IEnumerable<HotelDTO> Get()
        {
            return _hotelService.GetAll();
        }

        // POST api/<HotelsController>
        [HttpPost]
        public void Post(HotelDTO hotel)
        {
            _hotelService.Add(hotel);
        }

        // DELETE api/<HotelsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _hotelService.Delete(id);
        }
    }
}

using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryCityController : ControllerBase
    {
        private readonly CountryCityService _service;
        public CountryCityController()
        {
            _service = new CountryCityService();
        }
        // GET: api/<CountryCityController>
        [HttpGet]
        public IEnumerable<CountryCityDTO> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("Cities")]
        public IEnumerable<CityDTO> GetCities()
        {
            return _service.GetCities();
        }


        [HttpGet("Countries")]
        public IEnumerable<CountryDTO> GetCountries()
        {
            return _service.GetCountries();
        }

        // POST api/<CountryCityController>
        [HttpPost]
        public void Post(int cityId, int countryId)
        {
            _service.Add(cityId, countryId);
        }

        [HttpPost("City")]
        public void PostCity(CityDTO city)
        {
            _service.AddCity(city);
        }

        [HttpPost("Country")]
        public void PostCountry(CountryDTO country)
        {
            _service.AddCountry(country);
        }

        // DELETE api/<CountryCityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }

        [HttpDelete("City/{id}")]
        public void DeleteCity(int id)
        {
            _service.DeleteCity(id);
        }

        [HttpDelete("Country/{id}")]
        public void DeleteCountry(int id)
        {
            _service.DeleteCountry(id);
        }
    }
}

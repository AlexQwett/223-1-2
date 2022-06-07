using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilteredToursController : ControllerBase
    {
        private readonly FilteredToursService _service;
        public FilteredToursController()
        {
            _service = new FilteredToursService();
        }

        // GET: api/<FilteredToursController>
        [HttpGet]
        public IEnumerable<FilteredTourDTO> Get()
        {
            return _service.GetAll(DefaultCategory.Default);
        }

        [HttpGet("category/{category?}")]
        public IEnumerable<FilteredTourDTO> Get(string? category)
        {
            if(category is not null)
            {
                if (category.ToLower() is "hot")
                    return _service.GetAll(DefaultCategory.Hot);
                if (category.ToLower() is "nothot")
                    return _service.GetAll(DefaultCategory.NotHot);
            }

            return _service.GetAll(DefaultCategory.Default);
        }

        [HttpGet("{id}")]
        public FilteredTourDTO Get(int id)
        {
            return _service.Get(id);
        }

        [HttpGet("{category}/{city}/{rating}")]
        public IEnumerable<FilteredTourDTO> Get(string category, string city, byte rating)
        {
            return _service.GetAllBy(category, city, rating);
        }

        [HttpPost]
        public void Post(int tourId, int categoryId)
        {
            _service.Associate(tourId, categoryId);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}

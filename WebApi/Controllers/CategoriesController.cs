using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoriesService _service;
        public CategoriesController()
        {
            _service = new CategoriesService();
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<CategoryDTO> Get()
        {
            return _service.GetAll();
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post(CategoryDTO category)
        {
            _service.Add(category);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}

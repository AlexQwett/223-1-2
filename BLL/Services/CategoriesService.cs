using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Entities;

namespace BLL.Services
{
    public class CategoriesService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoriesService()
        {
            _unitOfWork = UnitOfWork.Unit;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<BLLProfile>()).CreateMapper();
        }

        public List<CategoryDTO> GetAll()
        {
            var categories = _unitOfWork.Categories.GetAll();
            var dtos = new List<CategoryDTO>();
            foreach (var item in categories)
                dtos.Add(_mapper.Map<CategoryDTO>(item));
            return dtos;
        }

        public CategoryDTO Get(string category)
        {
            return _mapper.Map<CategoryDTO>
                (_unitOfWork.Categories.GetAll().FirstOrDefault(x => x.Title == category));
        }

        public void Add(CategoryDTO category)
        {
            _unitOfWork.Categories.Add(_mapper.Map<Category>(category));
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.Categories.Delete(id);
            _unitOfWork.Save();
        }
    }
}

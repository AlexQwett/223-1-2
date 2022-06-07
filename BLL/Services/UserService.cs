using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Entities;

namespace BLL.Services
{
    public class UserService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService()
        {
            _unitOfWork = UnitOfWork.Unit;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<BLLProfile>()).CreateMapper();
        }

        public void Add(UserDTO user)
        {
            _unitOfWork.Users.Add(_mapper.Map<User>(user));
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.Users.Delete(id);
            _unitOfWork.Save();
        }

        public UserDTO Get(string email, string password)
        {
            /*var user = _unitOfWork.Users.GetAll();//.FirstOrDefault(x => x.Login == email && x.Password == password));
            foreach (var a in user)
                Console.WriteLine(a.Login + " " + a.Password);*/

            var users = _unitOfWork.Users.GetAll().ToList();
            for(int i = 0; i < users.Count; ++i)
            {
                if (users[i].Login is not null)
                    users[i].Login = users[i].Login.Replace(" ", "");
                if (users[i].Password is not null)
                    users[i].Password = users[i].Password.Replace(" ", "");
            }

            return _mapper.Map<UserDTO>(users.FirstOrDefault(x => (x.Login == email && x.Password == password)));
        }
    }
}

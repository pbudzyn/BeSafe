using System.Collections.Generic;
using System.Linq;
using PlaceNetwork.BusinessLogic.Repositories;
using PlaceNetwork.BusinessLogic.Services.Interfaces;
using PlaceNetwork.Data.Models;

namespace PlaceNetwork.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWorkFactory _factory;

        public UserService(IUnitOfWorkFactory factory)
        {
            _factory = factory;
        }

        public User Add(User user)
        {
            using (var unitOfWork = _factory.CreateUnitOfWork())
            {
                if (user == null) return null;
                var result = unitOfWork.UserRepository.Insert(user);
                unitOfWork.Save();
                return result;
            }
        }

        public void Delete(int id)
        {
            using (var unitOfWork = _factory.CreateUnitOfWork())
            {
                unitOfWork.UserRepository.Delete(id);
                unitOfWork.Save();
            }
        }

        public void Update(User user)
        {
            using (var unitOfWork = _factory.CreateUnitOfWork())
            {
                unitOfWork.UserRepository.Update(user);
                unitOfWork.Save();
            }
        }

        public User GetById(int id)
        {
            using (var unitOfWork = _factory.CreateUnitOfWork())
            {
                return unitOfWork.UserRepository.GetById(id);
            }
        }

        public User GetByUsername(string username)
        {
            using (var unitOfWork = _factory.CreateUnitOfWork())
            {
                return unitOfWork.UserRepository.Get(x => x.Username.Equals(username)).FirstOrDefault();
            }
        }

        public User GetByName(string name)
        {
            using (var unitOfWork = _factory.CreateUnitOfWork())
            {
                return unitOfWork.UserRepository.Get(x => x.Username.Equals(name)).FirstOrDefault();
            }
        }

        public User GetByEmail(string email)
        {
            using (var unitOfWork = _factory.CreateUnitOfWork())
            {
                return unitOfWork.UserRepository.Get(x => x.Email.Equals(email.ToLower())).FirstOrDefault();
            }
        }

        public User GetByLogin(string login)
        {
            using (var unitOfWork = _factory.CreateUnitOfWork())
            {
                return unitOfWork.UserRepository.Get(x => x.Login.Equals(login)).FirstOrDefault();
            }
        }

        List<User> IUserService.GetAll()
        {
            using (var unitOfWork = _factory.CreateUnitOfWork())
            {
                return unitOfWork.UserRepository.Get().ToList();
            }
        }
    }
}

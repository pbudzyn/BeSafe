using System.Collections.Generic;
using PlaceNetwork.Data.Models;

namespace PlaceNetwork.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        User Add(User user);
        void Delete(int id);
        void Update(User user);
        User GetById(int id);
        User GetByUsername(string username);
        User GetByEmail(string email);
        User GetByLogin(string login);
        List<User> GetAll();
    }
}
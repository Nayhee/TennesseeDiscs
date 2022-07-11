using TennesseeDiscs.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace TennesseeDiscs.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByEmail(string email);
        List<UserType> GetUserTypes();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
    }
}

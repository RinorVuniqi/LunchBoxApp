using System.Collections.Generic;
using System.Threading.Tasks;
using LunchBoxApp.Domain.Models;

namespace LunchBoxApp.Domain.Services.Abstract
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetLoginUser(string username, string password);
        Task<User> GetCurrentUser();
        Task SaveExistingUser(User user);
        Task CreateNewUser(User user);
    }
}

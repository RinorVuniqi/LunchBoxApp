using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchBoxApp.Domain.Models;
using LunchBoxApp.Domain.Services.Abstract;

namespace LunchBoxApp.Domain.Services.Mock
{
    public class UserService : IUserService
    {
        /// <summary>
        /// Generate users
        /// </summary>
        private static readonly List<User> Users = new List<User>()
        {
            new User
            {
                UserId = Guid.NewGuid(),
                UserName = "Rinor",
                UserFirstName = "Rinor",
                UserLastName = "Vuniqi",
                UserEmail = "rinor.vuniqi@hotmail.com",
                UserPassword = "rinor556"
            }
        };

        /// <summary>
        /// Returns all existing users
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            await Task.Delay(0);
            return Users;
        }

        /// <summary>
        /// Returns a user incase it exists (username + password combination)
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<User> GetLoginUser(string username, string password)
        {
            await Task.Delay(0);
            var user = Users.FirstOrDefault(u => u.UserName == username);
            if (user.UserPassword == password)
            {
                return user;
            }
            return null;
        }

        /// <summary>
        /// Saves an existing user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task SaveExistingUser(User user)
        {
            await Task.Delay(0);
            var oldUser = Users.FirstOrDefault(i => i.UserId == user.UserId);
            oldUser = user;
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task CreateNewUser(User user)
        {
            await Task.Delay(0);
            Users.Add(user);
        }
    }
}

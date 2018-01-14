using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunchBoxApp.Domain.Models;
using LunchBoxApp.Domain.Services.Abstract;
using LunchBoxApp.Domain.Services.SQLite;

namespace LunchBoxApp.Domain.Services.SQLite
{
    public class UserService : SQLiteServiceBase, IUserService
    {
        private static List<User> Users = new List<User>();

        public UserService()
        {
            try
            {
                Users = connection.Table<User>().ToList();

                if (Users.Count == 0)
                {
                    GenerateData();
                    Users = connection.Table<User>().ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

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


            //Dropping & recreating table here because "InsertOrReplace" always inserts, it isn't replacing
            connection.DropTable<User>();
            connection.CreateTable<User>();

            foreach (var _user in Users)
            {
                connection.InsertOrReplace(_user);
            }

            var test = connection.Table<User>().ToList();
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
            connection.InsertOrReplace(user);
        }

        private void GenerateData()
        {
            try
            {
                connection.Insert(new User
                {
                    UserId = Guid.NewGuid(),
                    UserName = "Rinor",
                    UserFirstName = "Rinor",
                    UserLastName = "Vuniqi",
                    UserEmail = "rinor.vuniqi@hotmail.com",
                    UserPassword = "rinor556"
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
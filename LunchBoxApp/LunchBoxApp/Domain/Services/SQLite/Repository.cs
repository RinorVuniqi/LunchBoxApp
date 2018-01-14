using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LunchBoxApp.Domain.Models;
using LunchBoxApp.Domain.Services.Abstract;
using SQLite;

namespace LunchBoxApp.Domain.Services.SQLite
{
    public class Repository : IRepository
    {
        private readonly SQLiteAsyncConnection db;

        public Repository(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<User>().Wait();
        }

        public Task<List<User>> GetAllUsers()
        {
            return db.Table<User>().ToListAsync();
        }

        public async Task CreateUser(User user)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(user.UserName))
                {
                    await db.InsertOrReplaceAsync(user);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}

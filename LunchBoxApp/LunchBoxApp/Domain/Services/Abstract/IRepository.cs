using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LunchBoxApp.Domain.Models;

namespace LunchBoxApp.Domain.Services.Abstract
{
    public interface IRepository
    {
        Task<List<User>> GetAllUsers();
        Task CreateUser(User user);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LunchBoxApp.Domain.Models;

namespace LunchBoxApp.Domain.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(Guid id);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LunchBoxApp.Domain.Models;

namespace LunchBoxApp.Domain.Services.Abstract
{
    public interface ISubcategoryService
    {
        Task<IEnumerable<Subcategory>> GetAllSubcategories();
        Task<Subcategory> GetSubcategoryBySubcategoryId(Guid id);
        Task<IEnumerable<Subcategory>> GetSubcategoriesByCategoryId(Guid id);
    }
}

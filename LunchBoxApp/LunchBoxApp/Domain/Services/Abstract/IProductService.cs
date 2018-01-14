using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LunchBoxApp.Domain.Models;

namespace LunchBoxApp.Domain.Services.Abstract
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAlProducts();
        Task<Product> GetProductByProductId(Guid id);
        Task<IEnumerable<Product>> GetProductBySubcategoryId(Guid id);
        Task<Product> GetProductOfTheWeek();
    }
}

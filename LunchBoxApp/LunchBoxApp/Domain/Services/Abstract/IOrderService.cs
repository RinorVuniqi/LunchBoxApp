using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LunchBoxApp.Domain.Models;

namespace LunchBoxApp.Domain.Services.Abstract
{
    public interface IOrderService
    {
        Task<Order> GetOrder();
        Task SaveProductToOrder(Product product);
        Task SaveOrder(Order order);
        Task RemoveProductFromOrder(Product product);
        Task ClearOrderProducts();
        Task UpdateOrderPriceAndCount(int count, decimal price);
        Task UpdateOrderPayment(Payment payment);
        Task UpdateOrderCompany(string company);
    }
}

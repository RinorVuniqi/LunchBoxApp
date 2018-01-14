using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LunchBoxApp.Domain.Models;
using LunchBoxApp.Domain.Services.Abstract;

namespace LunchBoxApp.Domain.Services.SQLite
{
    public class OrderService : IOrderService
    {
        public Order Order = new Order() { OrderId = Guid.NewGuid(), Products = new List<Product>() };

        public async Task<Order> GetOrder()
        {
            await Task.Delay(0);
            return Order;
        }

        public async Task SaveOrder(Order order)
        {
            await Task.Delay(0);
            Order = order;
        }

        public async Task SaveProductToOrder(Product product)
        {
            await Task.Delay(0);
            Order.Products.Add(product);

        }

        public async Task RemoveProductFromOrder(Product product)
        {
            await Task.Delay(0);
            Order.Products.Remove(product);
        }

        public async Task ClearOrderProducts()
        {
            await Task.Delay(0);
            Order.Products.Clear();
            Order.OrderId = Guid.NewGuid();
        }

        public async Task UpdateOrderPriceAndCount(int count, decimal price)
        {
            await Task.Delay(0);
            Order.OrderTotalPrice = price;
            Order.OrderTotalProductCount = count;
        }

        public async Task UpdateOrderPayment(Payment payment)
        {
            await Task.Delay(0);
            Order.OrderPayment = payment;
        }

        public async Task UpdateOrderCompany(string company)
        {
            await Task.Delay(0);
            Order.OrderCompanyName = company;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LunchBoxApp.Domain.Models;

namespace LunchBoxApp.Domain.Services.Mock
{
    public class PaymentService : IPaymentService
    {
        private static readonly List<Payment> Payments = new List<Payment>()
        {
            new Payment
            {
                PaymentId = Guid.NewGuid(),
                PaymentName = "Cash"
            },

            new Payment
            {
                PaymentId = Guid.NewGuid(),
                PaymentName = "Overschrijving"
            },

            new Payment
            {
                PaymentId = Guid.NewGuid(),
                PaymentName = "Bancontact"
            },

            new Payment
            {
                PaymentId = Guid.NewGuid(),
                PaymentName = "Mastercard"
            },

            new Payment
            {
                PaymentId = Guid.NewGuid(),
                PaymentName = "Visa"
            },

            new Payment
            {
                PaymentId = Guid.NewGuid(),
                PaymentName = "Payconic"
            },

            new Payment
            {
                PaymentId = Guid.NewGuid(),
                PaymentName = "Cadeaubon"
            }
        };

        public async Task<List<Payment>> GetPayments()
        {
            await Task.Delay(0);
            return Payments;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LunchBoxApp.Domain.Models
{
    public interface IPaymentService
    {
        Task<List<Payment>> GetPayments();
    }
}

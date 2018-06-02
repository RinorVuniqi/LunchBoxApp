using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LunchBoxApp.Domain.Models;
using Newtonsoft.Json;

namespace LunchBoxApp.Domain.Services.SQLite
{
    public class PaymentService : IPaymentService
    {
        private static List<Payment> Payments = new List<Payment>();

        public PaymentService()
        {
            Task.Run(GetJson);
        }

        public async Task<List<Payment>> GetPayments()
        {
            await Task.Delay(0);
            return Payments;
        }

        private async Task GetJson()
        {
            try
            {
                string url = new Constants().url + "payments";

                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync(new Uri(url));

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Payments = JsonConvert.DeserializeObject<List<Payment>>(content);
                }
            }

            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }

        }
        //{
        //    new Payment
        //    {
        //        PaymentId = Guid.NewGuid(),
        //        PaymentName = "Cash"
        //    },

        //    new Payment
        //    {
        //        PaymentId = Guid.NewGuid(),
        //        PaymentName = "Overschrijving"
        //    },

        //    new Payment
        //    {
        //        PaymentId = Guid.NewGuid(),
        //        PaymentName = "Bancontact"
        //    },

        //    new Payment
        //    {
        //        PaymentId = Guid.NewGuid(),
        //        PaymentName = "Mastercard"
        //    },

        //    new Payment
        //    {
        //        PaymentId = Guid.NewGuid(),
        //        PaymentName = "Visa"
        //    },

        //    new Payment
        //    {
        //        PaymentId = Guid.NewGuid(),
        //        PaymentName = "Payconic"
        //    },

        //    new Payment
        //    {
        //        PaymentId = Guid.NewGuid(),
        //        PaymentName = "Cadeaubon"
        //    }
        //};
    }
}

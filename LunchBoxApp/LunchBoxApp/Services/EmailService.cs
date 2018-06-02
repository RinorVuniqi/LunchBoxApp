using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using LunchBoxApp.Domain.Models;
using Newtonsoft.Json;

namespace LunchBoxApp.Services
{
    public class EmailService
    {
        private readonly NetworkCredential login;
        private readonly MailMessage mail;
        private readonly SmtpClient client;

        public EmailService()
        {
            login = new NetworkCredential("Lunchbox8210@gmail.com", "Lunchbox556");
            mail = new MailMessage();
            client = new SmtpClient();
        }

        public async Task<bool> SendEmail(Order order)
        {
            await Task.Delay(0);

            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = login;

            mail.Subject = $"Bestelling: {order.OrderId}";
            mail.Body = $"Gebruiker: {order.OrderUser.UserName}{Environment.NewLine}" +
                        $"Email: {order.OrderUser.UserEmail}{Environment.NewLine}" +
                        $"Betaalmethode: {order.OrderPayment.PaymentName}{Environment.NewLine}" +
                        $"Levering: {order.OrderCompanyName}{Environment.NewLine}" +
                        $"Totaal: {order.OrderTotalProductCount} St | € {order.OrderTotalPrice}{Environment.NewLine}{Environment.NewLine}";

            foreach (var product in order.Products)
            {
                mail.Body += $"Artikel: {product.ProductName}{Environment.NewLine}" +
                             $"Aantal: {product.ProductQuantity}{Environment.NewLine}" +
                             $"Prijs: € {product.ProductPrice}{Environment.NewLine}";

                if (!string.IsNullOrEmpty(product.ProductPersonName))
                {
                    mail.Body += $"Persoon: {product.ProductPersonName}{Environment.NewLine}";
                }

                if (!string.IsNullOrEmpty(product.ProductNote))
                {
                    mail.Body += $"Opmerking:{Environment.NewLine}{product.ProductNote}";
                }

                mail.Body += $"{Environment.NewLine}--------------------------------------{Environment.NewLine}";
            }

            mail.From = new MailAddress("Lunchbox8210@gmail.com");
            mail.To.Add(new MailAddress("rinor.vuniqi@hotmail.com"));

            try
            {
                client.Send(mail);
                await PostOrder(order);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task PostOrder(Order order)
        {
            await Task.Delay(0);
            var jsonData = JsonConvert.SerializeObject(order);

            using (var client = new HttpClient())
            {
                var respnonse = await client.PostAsync(
                    new Constants().url + "/orders",
                    new StringContent(jsonData, Encoding.UTF8, "application/json"));
                Debug.WriteLine(respnonse.ToString());
            }
        }
    }
}

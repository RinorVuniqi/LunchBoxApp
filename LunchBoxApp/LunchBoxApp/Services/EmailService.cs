using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using LunchBoxApp.Domain.Models;

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
            mail.Body = $"Betaalmethode: {order.OrderPayment.PaymentName}{Environment.NewLine}" +
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
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}

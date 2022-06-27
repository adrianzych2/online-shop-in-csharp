using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public static class MailService

    {

        public static void MailSender(Order order)
        {


            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("CodecoolShopg4@gmail.com", "jrwebbygswoaudzs"),
                EnableSsl = true
            };

            string message = CreateMessage(order);

            client.Send("CodecoolShopg4@gmail.com", order.UserData.Email, $"CodeCoolShop - order number {order.Id}", message);

        }

        private static string CreateMessage(Order order)
        {
            return $"Thank you for your order! Your Order ID: {order.Id}.";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BlogWebUI.Models
{
    public class Mail
    {
        public static void MailSender(string body)
        {

            var fromAddress = new MailAddress("talhayuksek46@gmail.com"); //gönderilecek mail
            var toAddress = new MailAddress("talhayuksek46@gmail.com");//gönderen mail
            const string subject = "Blogumdan| Sitenizden Gelen İletişim Formu";//başlık
            using (var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "8254282542")//mail ve şifre
            })
            {
                using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body })
                {
                    smtp.Send(message);
                }
            }
        }
    }
}

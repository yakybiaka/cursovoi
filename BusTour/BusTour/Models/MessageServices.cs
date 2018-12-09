using System;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace BusTour.Models
{
    public class MessageServices
    {
        public async static Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var _email = "julia.yakybeika@gmail.com";
                var _epass = ConfigurationManager.AppSettings["EmailPassword"];
                var _dispName = "DisplayName";
                MailMessage myMessage = new MailMessage();              
                myMessage.To.Add(email);
                myMessage.From = new MailAddress(_email, _dispName);
                myMessage.Subject = subject;
                myMessage.Body = message;
                myMessage.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.EnableSsl = true;
                    smtp.Host = "smtp.live.com"; //if using hotmail to send emails 
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(_email, _epass);
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.SendCompleted += (s, e) => { smtp.Dispose(); };
                    await smtp.SendMailAsync(myMessage);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async static Task SendBulkEmailAsync(string[] emails, string subject, string message)
        {
            try
            {
                var _email = "yourEmail";
                var _epass = ConfigurationManager.AppSettings["EmailPassword"];
                var _dispName = "DisplayName";
                MailMessage myMessage = new MailMessage();
                foreach (var email in emails)
                {
                    myMessage.To.Add(email);
                }
                myMessage.From = new MailAddress(_email, _dispName);
                myMessage.Subject = subject;
                myMessage.Body = message;
                myMessage.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.EnableSsl = true;
                    smtp.Host = "smtp.live.com"; //if using hotmail to send emails 
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(_email, _epass);
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.SendCompleted += (s, e) => { smtp.Dispose(); };
                    await smtp.SendMailAsync(myMessage);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
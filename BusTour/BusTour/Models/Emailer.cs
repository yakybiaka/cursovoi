using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace BusTour.Models
{
    public class Emailer
    {
        public static void Send(string email)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(email);
            msg.Subject="Котик";
            msg.Body = "Люблю своего кота очень-очень!!!";
            msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Send(msg);
        } 
    }
}
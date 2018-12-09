using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace BusTour.Models
{
    public class Emailer
    {
        public static void Send(string email, string sender_name, string tour_name)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.To.Add(email);
                msg.Subject = "Application for a tour" + tour_name;
                msg.Body = "Dear, " + sender_name + "<br/><br/>" + "Your application for the tour " + tour_name + " accepted. Our specialist will contact with you during the day. <br></br>Thank you for your application! Have a nice day!<br><br> Best regards,<br></br> BusDreamsCompany";
                msg.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Send(msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
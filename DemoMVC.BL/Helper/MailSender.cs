using DemoMVC.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.BL.Helper
{
    public static class MailSender
    {
        public static string Send( MailVM mail)
        {
            try
            {

                var smtp = new SmtpClient("smtp-mail.outlook.com", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("abdom44@outlook.com", "01516277132@Aa");
                smtp.Send("abdom44@outlook.com", mail.Receiver, mail.Title, mail.Message);
                return "success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

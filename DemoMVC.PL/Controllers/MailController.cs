using DemoMVC.BL.Helper;
using DemoMVC.BL.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
namespace DemoMVC.PL.Controllers
{
    public class MailController : Controller
    {
        public IActionResult SendMail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMail(MailVM mail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                       

                    TempData["msg"] = MailSender.Send(mail);
                    return RedirectToAction("SendMail");
                }

                return View();
            }
            catch (Exception ex)
            {
                TempData["msg"] = MailSender.Send(mail);
            }
            return View();
        }
    }
}

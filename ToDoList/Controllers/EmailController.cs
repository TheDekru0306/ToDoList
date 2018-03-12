using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class EmailController : Controller
    {
        [Authorize(Users = "Denny Krumov")]
        public ActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Users = "Denny Krumov")]        
        public ActionResult SendEmail(EmailViewModel model)
        {
            using (MailMessage mm = new MailMessage("videofx159@gmail.com", model.To))
            {
                var Emails = new MailAddressCollection();

                mm.Subject = model.Subject;
                mm.Body = model.Body;

                mm.IsBodyHtml = false;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential("videofx159@gmail.com", "");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                    ViewBag.Message = "Email sent.";
                }
            }

            return View("../Home/Index");
        }
    }
}
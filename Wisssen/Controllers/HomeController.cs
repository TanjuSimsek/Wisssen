using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wisssen.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(string firstName,string lastName,string email,string phone, string department,string message)
        {
          
            //todo mail gönderme işlemi yapılcak 
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();

            mailMessage.From = new System.Net.Mail.MailAddress("gonderen@gmail.com", "Gönderen Firma Adı");
            mailMessage.Subject = "İletişim Formu: " + firstName;

            mailMessage.To.Add("alici@firmaadi.com,digeralici@gmail.com");

            string body;
            body = "Ad Soyad: " + firstName+" "+lastName + "<br />";
            body += "Telefon: " + phone + "<br />";
            body += "E-posta: " + email + "<br />";
            body += "Telefon: " + phone + "<br />";
            body += "Mesaj: " + message + "<br />";
            body += "Bölüm: " + department + "<br />";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = body;

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential("gonderen@gmail.com", "gondereninmailsifresi");
            smtp.EnableSsl = true;
            smtp.Send(mailMessage);
            ViewBag.Message = "Mesajınız gönderildi. Teşekkür ederiz.";


            return View();
        }
    }
}
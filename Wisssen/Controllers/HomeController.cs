﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        public ActionResult DenemeForm() {

            return View();
        }
        [HttpPost]
        public ActionResult DenemeForm(Wisssen.Models.DenemeForm model)
        {
            if (ModelState.IsValid) {

               

                bool hasError = false;
                try {

                    System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();

                    mailMessage.From = new System.Net.Mail.MailAddress("gonderen@gmail.com", "Gönderen Firma Adı");
                    mailMessage.Subject = "İletişim Formu: " + model.FirstName;

                    mailMessage.To.Add("alici@firmaadi.com,digeralici@gmail.com");

                    string body;
                    body = "Ad Soyad: " + model.FirstName + " " + model.LastName + "<br />";
                    body += "Telefon: " + model.Phone + "<br />";
                    body += "E-posta: " + model.Email + "<br />";


                    mailMessage.IsBodyHtml = true;
                    mailMessage.Body = body;

                    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                    smtp.Credentials = new System.Net.NetworkCredential("gonderen@gmail.com", "gondereninmailsifresi");
                    smtp.EnableSsl = true;
                    smtp.Send(mailMessage);
                    // ViewBag.Message = "Mesajınız gönderildi. Teşekkür ederiz.";

                    ViewBag.Message = "Mail Başarıyla Gönderikldi";



                    //mail gönder
                    // throw new Exception("Mail sunucusuna ulaşılmıyor!Lütfen daha sonra tekrar deneyin");

                } catch (Exception ex) {

                    ModelState.AddModelError("Error", ex.Message);
                    hasError = true;
                    
                }
                if (hasError == false) {
                    ViewBag.Message = "Mail Sunucusuna Erişelemiyor";

                }
                
                return View();
            }



            return View();



        }
        [HttpPost]
        public ActionResult Contact(string firstName,string lastName,string email,string phone, string department,string message)
        {// 
            firstName = firstName.Trim();
            lastName = lastName.Trim();
            if (firstName == "") {

                ViewBag.Message = "Ad Alanını Giriniz..";
                ViewBag.IsError = true;
                return View();

            }
            if (firstName.Length > 50) {

                ViewBag.Message = "Ad Alanını 50 karakterden uzun olamaz";
                ViewBag.IsError = true;
                return View();

            }
            if (lastName=="")
            {

                ViewBag.Message = "Soyad Gereklidir";
                ViewBag.IsError = true;
                return View();

            }
            Regex regex = new Regex(@"^5(0[5-7]|[3-5]\d) ?\d{3} ?\d{4}$");
            Match match = regex.Match(phone);
            if (match.Success == false) {

                ViewBag.Message = "Telefon 5XX XXX XXXX formatında giriniz";
                ViewBag.IsError = true;
                return View();

            }
            

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
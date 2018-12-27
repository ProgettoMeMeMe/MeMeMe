using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeMeMe.Models;
using System.Data.SqlClient;


namespace MeMeMe.Controllers
{
    public class SendMailerController
    {
        /*public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ViewResult Index(MailMeMeMe m)
        {
            if (ModelState.IsValid)
            {
                MailMeMeMe mail = new MailMeMeMe();
                mail.To.Add(m.To);
                mail.From = new MailAddress(m.From);
                mail.Subject = m.Subject;
                string Body = m.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("username", "password");// Enter seders User name and password  
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return View("Index", m);
            }
            else
            {
                return View();
            }
        }*/
    }
}
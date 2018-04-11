using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using testD.Models;

namespace testD.Controllers
{
    public class HomeController : Controller
    {
        private Database1Entities db = new Database1Entities();
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


        public ActionResult Admin()
        {
            ViewBag.Message = "Admin  page.";

            return View();
        }

        public ActionResult Documentation()
        {

            ViewBag.Message = "Documentation  page.";
            return View();
        }


        public ActionResult FAQ()
        {

            ViewBag.Message = "FAQ  page.";
            return View();
        }

        public ActionResult SendEmail()
        {

            ViewBag.userdetails = db.Customers;
            return View();
        }


        public ActionResult Sent()
        {


            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendEmail(EmailFormModel model)
        {

            


            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                String[] addresses = model.ToEmail.Split(';');

                foreach (var address in addresses){
                    if(address != "")
                    {
                        message.To.Add(address);
                    }
                    
                }


                //message.To.Add(new MailAddress(model.ToEmail));  // replace with valid value 
                message.From = new MailAddress("yfan150@student.monash.edu");  // replace with valid value
                message.Subject = "Test Email from .ASP MVC";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                if (model.Upload != null && model.Upload.ContentLength > 0)
                {
                    message.Attachments.Add(new Attachment(model.Upload.InputStream, Path.GetFileName(model.Upload.FileName)));
                }

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "yfan150@student.monash.edu",  // replace with valid value
                        Password = "11901084Fym"  // replace with valid value
                    };
                    smtp.Credentials = new System.Net.NetworkCredential("yfan150@student.monash.edu", "11901068Fym");
                    smtp.UseDefaultCredentials = false;
                    smtp.Host = "smtp.monash.edu.au";
                    //smtp.Port = 587;
                    //smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }







    }
}
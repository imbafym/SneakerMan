using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using testD.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.IO;

namespace testD.Controllers
{
    public class CustomersController : Controller
    {
        private Database1Entities db = new Database1Entities();

       

        // GET: Customers
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: User's Customer info
        public ActionResult IndexUserView()
        {
            //return View(db.Artiles.ToList());
            string currentUserId = User.Identity.GetUserId();
            return View(db.Customers.Where(m => m.customerEmail == currentUserId).ToList());
        }

        public ActionResult IndexForRegister()
        {
            return View(db.Customers.ToList());
        }


        public ActionResult SearchPage()
        {
            return View();
        }




        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }


        //GET: Custoemrs logged in details
        public ActionResult DetailsLoggedIn()
        {

            return View();

        }




        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customerId,customerFName,customerLName,customerAddress,customerPhone,customerEmail,customerState")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

      
        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateIndividual([Bind(Include = "customerId,customerFName,customerLName,customerAddress,customerPhone,customerEmail,customerState")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index", "Manage");
            }

            //string currentUserEmail = HttpContext.GetOwinContext()
            //       .GetUserManager<ApplicationUserManager>()
            //       .FindById(User.Identity.GetUserId()).Email;
            //int currentDBuserID = -1;
            //string currentDBuserAddress = "";
            //string currentDBuserFName = "";
            //string currentDBuserLName = "";
            //string currentDBuserPhone = "";
            //string currentDBuserState = "";


            ////foreach (var item in db.Customers)
            ////{
            ////    if (item.customerEmail == currentUserEmail)
            ////    {
            ////        flag = true;
            ////        currentDBuserID = item.customerId;
            ////        currentDBuserAddress = item.customerAddress;
            ////        currentDBuserFName = item.customerFName;
            ////        currentDBuserLName = item.customerLName;
            ////        currentDBuserPhone = item.customerPhone;
            ////        currentDBuserState = item.customerState;
            ////    }else
            ////    {

            ////    }
            ////}


            ////Customer c = new Customer();
            ////c.customerEmail = currentUserEmail;
            ////if (flag)
            ////{
            ////    c.customerId = currentDBuserID;
            ////    c.customerFName = currentDBuserFName;
            ////    c.customerLName = currentDBuserLName;
            ////    c.customerPhone = currentDBuserPhone;
            ////    c.customerState = currentDBuserState;
            ////    c.customerAddress = currentDBuserAddress;
            ////}

            //Boolean flag = false;
            //foreach (var item in db.Customers)
            //{
            //    if (item.customerEmail == currentUserEmail)
            //    {
            //        flag = true;
            //        currentDBuserID = item.customerId;

            //    }
            //}


            //Customer c = db.Customers.Find(currentDBuserID);

            //return View(c);


            string currentUserEmail = HttpContext.GetOwinContext()
               .GetUserManager<ApplicationUserManager>()
               .FindById(User.Identity.GetUserId()).Email;
            int currentDBuserID = -1;
            string currentDBuserAddress = "";
            string currentDBuserFName = "";
            string currentDBuserLName = "";
            string currentDBuserPhone = "";
            string currentDBuserState = "";

            Boolean flag = false;
            int i = 0;
            foreach (var item in db.Customers)
            {
                if (item.customerEmail == currentUserEmail)
                {
                    flag = true;
                    currentDBuserID = item.customerId;

                }
                i = i + 1;
            }





            if (flag)
            {
                Customer c = db.Customers.Find(currentDBuserID);
                return View(c);
            }
            else
            {
                Customer c = new Customer();
                //c.customerId = i + 1;
                c.customerEmail = currentUserEmail;
                return View(c);
            }


        }
        // GET: Customers/Create
        [Authorize]
        public ActionResult CreateIndividual()
        {
            string currentUserEmail = HttpContext.GetOwinContext()
                   .GetUserManager<ApplicationUserManager>()
                   .FindById(User.Identity.GetUserId()).Email;
            int currentDBuserID = -1;
            string currentDBuserAddress = "";
            string currentDBuserFName = "";
            string currentDBuserLName = "";
            string currentDBuserPhone = "";
            string currentDBuserState = "";
            
            Boolean flag = false;
            int i = 0;
            foreach(var item in db.Customers)
            {
                if(item.customerEmail == currentUserEmail)
                {
                    flag = true;
                    currentDBuserID = item.customerId;

                }
                i = i + 1;
            }


          
           

            if (flag)
            {
                Customer c = db.Customers.Find(currentDBuserID);
                return View(c);
            }else
            {
                Customer c = new Customer();
                //c.customerId = i + 1;
                c.customerEmail = currentUserEmail;
                return View(c);
            }

            
            
        
                
            
         
        }


        public ActionResult UploadImage()
        {
            return View();
        }



        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase postedFile)
        {
            String strExt = System.IO.Path.GetExtension(postedFile.FileName);
            string currentUserEmail = HttpContext.GetOwinContext()
                 .GetUserManager<ApplicationUserManager>()
                 .FindById(User.Identity.GetUserId()).Email;
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/" + currentUserEmail + "/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (postedFile.ContentLength > 2000000)
                {
                    ViewBag.Message = "File is larger than 2 MB";
                }
                if ((strExt.ToLower() != ".gif") && (strExt.ToLower() != ".jpg"))
                {
                    ViewBag.Message = "Invalid File Type";
                }
                else
                {
                    postedFile.SaveAs(path + currentUserEmail + ".png");
                    ViewBag.Message = "File uploaded successfully.";
                }

            }

            return View();
        }




        public ActionResult ViewImage()
        {
            string currentUserEmail = HttpContext.GetOwinContext()
               .GetUserManager<ApplicationUserManager>()
               .FindById(User.Identity.GetUserId()).Email;
            ViewBag.Message = currentUserEmail;

            return View();

        }






        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customerId,customerFName,customerLName,customerAddress,customerPhone,customerEmail,customerState")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

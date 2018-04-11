using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using testD.Models;

namespace testD.Controllers
{
    public class ShoesOrdersController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: ShoesOrders
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            var shoesOrders = db.ShoesOrders.Include(s => s.Customer);
            return View(shoesOrders.ToList());
        }


        // GET: Artiles
        
        public ActionResult IndexUserOrders()
        {
            
            string currentUserEmail = HttpContext.GetOwinContext()
                   .GetUserManager<ApplicationUserManager>()
                   .FindById(User.Identity.GetUserId()).Email;

            Boolean flag = false;
            int currentDBuserID = -1;

            foreach (var item in db.Customers)
            {
                if (item.customerEmail == currentUserEmail)
                {
                    flag = true;
                    currentDBuserID = item.customerId;

                }
            }

            return View(db.ShoesOrders.Where(m => m.customerId == currentDBuserID).ToList());
        }




        // GET: ShoesOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoesOrder shoesOrder = db.ShoesOrders.Find(id);
            if (shoesOrder == null)
            {
                return HttpNotFound();
            }
            return View(shoesOrder);
        }

        // GET: ShoesOrders/Create
        public ActionResult Create()
        {
            ViewBag.customerId = new SelectList(db.Customers, "customerId", "customerFName");
            return View();
        }

        // POST: ShoesOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orderId,orderDate,customerId,orderPrice,quantity,shoesName,comments")] ShoesOrder shoesOrder)
        {
            if (ModelState.IsValid)
            {
                db.ShoesOrders.Add(shoesOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customerId = new SelectList(db.Customers, "customerId", "customerFName", shoesOrder.customerId);
            return View(shoesOrder);
        }



       
        // POST: Artiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateIndividual([Bind(Include = "orderId,orderDate,customerId,orderPrice,quantity,shoesName,comments")] ShoesOrder shoesOrder)
        {
            if (ModelState.IsValid)
            {
                db.ShoesOrders.Add(shoesOrder);
                db.SaveChanges();
                return RedirectToAction("IndexUserOrders");
            }
            ShoesOrder order = new ShoesOrder();
            string currentUserEmail = HttpContext.GetOwinContext()
                   .GetUserManager<ApplicationUserManager>()
                   .FindById(User.Identity.GetUserId()).Email;
            Boolean flag = false;
            int currentDBuserID = -1;

            foreach (var item in db.Customers)
            {
                if (item.customerEmail == currentUserEmail)
                {
                    flag = true;
                    currentDBuserID = item.customerId;

                }
            }

            order.customerId = currentDBuserID;
            return View(order);
        }

        // GET: Artiles/Create
        [Authorize]
        public ActionResult CreateIndividual()
        {
            string currentUserEmail = HttpContext.GetOwinContext()
                   .GetUserManager<ApplicationUserManager>()
                   .FindById(User.Identity.GetUserId()).Email;
            Boolean flag = false;
            int currentDBuserID = -1;
            string currentDBuserFName = "";
            string currentDBuserLName = "";

            foreach (var item in db.Customers)
            {
                if (item.customerEmail == currentUserEmail)
                {
                    flag = true;
                    currentDBuserID = item.customerId;
                    currentDBuserFName = item.customerFName;
                    currentDBuserLName = item.customerLName;

                }
            }

            if (flag)
            {
                ShoesOrder order = new ShoesOrder();

                order.customerId = currentDBuserID;
                order.comments = currentDBuserLName + " " + currentDBuserFName;
               

                return View(order);

            }


            return View("");
        }


        // GET: ShoesOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoesOrder shoesOrder = db.ShoesOrders.Find(id);
            if (shoesOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.customerId = new SelectList(db.Customers, "customerId", "customerFName", shoesOrder.customerId);
            return View(shoesOrder);
        }

        // POST: ShoesOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orderId,orderDate,customerId,orderPrice,quantity,shoesName,comments")] ShoesOrder shoesOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoesOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customerId = new SelectList(db.Customers, "customerId", "customerFName", shoesOrder.customerId);
            return View(shoesOrder);
        }

        // GET: ShoesOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoesOrder shoesOrder = db.ShoesOrders.Find(id);
            if (shoesOrder == null)
            {
                return HttpNotFound();
            }
            return View(shoesOrder);
        }

        // POST: ShoesOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoesOrder shoesOrder = db.ShoesOrders.Find(id);
            db.ShoesOrders.Remove(shoesOrder);
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

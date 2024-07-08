using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TI_Project.Models;

namespace TI_Project.Controllers
{
    [Authorize]

    public class PaymentMethodController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: PaymentMethod
        public ActionResult Index()
        {
            ViewBag.msg = TempData["msg"];
            // Retrieve categories from the database
            List<PaymentMethod> PaymentMethodsList = GetPaymentMehods();
            return View(PaymentMethodsList);
        }

        private List<PaymentMethod> GetPaymentMehods()
        {
            return db.PaymentMethods.ToList();
        }

        [Authorize(Roles = "admin")]
        // GET: PaymentMethod/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        // GET: PaymentMethod/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(PaymentMethod paymentMethod)
        {

            db.PaymentMethods.Add(paymentMethod);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [Authorize(Roles = "admin")]
        // GET: PaymentMethod/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        // POST: PaymentMethod/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "admin")]
        // GET: PaymentMethod/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaymentMethod/Delete/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TI_Project.Models;


namespace TI_Project.Controllers
{
    [Authorize]

    public class ExpenseController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Expense
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            List<Expense> Expenses = GetExpenses(userId);
            return View(Expenses);
        }

        private List<Expense> GetExpenses(string userId)
        {
            return db.Expenses
                     .Where(e => e.UserId == userId)  // Filter expenses based on userId
                     .Include(e => e.Category)        // Include related Category
                     .Include(e => e.PaymentMethod)   // Include related PaymentMethod
                     .ToList();
        }

        // GET: Expense/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Expense/Create
        public ActionResult Create()
        {
            ViewBag.CategoryList = new SelectList(db.Categories, "CategoryId", "Name");
            ViewBag.PaymentMethodList = new SelectList(db.PaymentMethods, "PaymentMethodId", "Name"); // Assuming you have a PaymentMethods table

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Expense expense)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    expense.UserId = User.Identity.GetUserId();
                    expense.CreatedAt = DateTime.Now;


                    db.Expenses.Add(expense);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                // If ModelState is not valid, repopulate the CategoryList and return the view
                ViewBag.CategoryList = new SelectList(db.Categories, "CategoryId", "Name", expense.CategoryId);
                ViewBag.PaymentMethodList = new SelectList(db.PaymentMethods, "PaymentMethodId", "Name", expense.PaymentMethodId);
                return View(expense);
            }
            catch
            {
                return View();
            }
        }

        // GET: Expense/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Expense/Edit/5
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

        // GET: Expense/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Expense/Delete/5
        [HttpPost]
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

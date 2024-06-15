using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TI_Project.Models;

namespace TI_Project.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // Display all categories
        public ActionResult Index()
        {
            ViewBag.msg = TempData["msg"];
            // Retrieve categories from the database
            List<Category> categories = GetCategories();
            return View(categories);
        }

        private List<Category> GetCategories()
        {
            return db.Categories.ToList();
        }


        // Add a new category
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {

            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {

            if (db.Categories.Find(id) != null)
            {
                Category c = db.Categories.Find(id);
                return View(c);
            }
            else
            {
                TempData["msg"] = "Category Not Found!";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            var existingCategory = db.Categories.Find(category.CategoryId);
            db.Entry(existingCategory).CurrentValues.SetValues(category);
            db.SaveChanges();
            TempData["msg"] = "Updated Sucesfully!!";
            return RedirectToAction("Index");


        }


        public ActionResult Delete(int id)
        {
            if (db.Categories.Find(id) != null)
            {
                Category c = db.Categories.Find(id);
                db.Categories.Remove(c);
                db.SaveChanges();
                TempData["msg"] = "Deleted Category Sucessfully!";
            }
            else
            {
                TempData["msg"] = "Category Not Found!";
            }
            return RedirectToAction("Index");

        }

        // Additional methods for Edit, Delete, etc.
    }
}
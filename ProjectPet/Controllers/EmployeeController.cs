using ProjectPet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectPet.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        Database1Entities2 db = new Database1Entities2();

        [HttpGet]
        public ActionResult Emp()
        {
            return View(db.Employees.ToList());

        }

       
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpId, EmpName, EmpMail, Gender, DOB, DOJ, Address")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Emp");
            }
            return View(employee);
        }


        public ActionResult Edit(Employee employee)
        {
            return View(employee);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost([Bind(Include = "EmpId, EmpName, EmpMail, Gender, DOB, DOJ, Address")] Employee employee)

        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Emp");
            }
            return View(employee);
        }

        public ActionResult Delete(Employee employee)
        {
            return View(employee);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int EmpId)
        {
            Employee employee = db.Employees.Find(EmpId);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Emp");
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

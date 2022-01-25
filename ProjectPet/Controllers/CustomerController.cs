using ProjectPet.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ProjectPet.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        Database1Entities2 db = new Database1Entities2();

        [HttpGet]
        public ActionResult Customer()
        {
            return View(db.Customers.ToList());
        }


        public ActionResult Edit(Customer customer)
        {
            return View(customer);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost([Bind(Include = "CustomerId, CustomerName, CustomerMail, CustomerGender, CustomerPhoneNo, CustomerAddress")] Customer customer)
            
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Customer");
            }
            return View(customer);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId, CustomerName, CustomerMail, CustomerGender, CustomerPhoneNo, CustomerAddress")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
            return View(customer);
        }

        public ActionResult Delete(Customer customer)
        {
            return View(customer);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int CustomerId)
        {
            Customer customer = db.Customers.Find(CustomerId);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Customer");
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
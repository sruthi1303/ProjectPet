using ProjectPet.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ProjectPet.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
       private Database1Entities2 db = new Database1Entities2();

        [HttpGet]
        public ActionResult Item()
        {
            return View(db.Items.ToList());
        }

        public ActionResult Edit(Item item)
        {
            return View(item);
        }
        [HttpPost, ActionName("IEdit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost([Bind(Include = "ItemId, ItemName, ItemPrice")] Item item)

        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Item");
            }
            return View(item);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId, ItemName, ItemPrice")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Item");
            }
            return View(item);
        }

        public ActionResult Delete(Item item)
        {
            return View(item);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int ItemId)
        {
            Item item = db.Items.Find(ItemId);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Item");
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
    
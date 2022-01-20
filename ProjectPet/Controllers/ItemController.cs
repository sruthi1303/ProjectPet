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

        public ActionResult IEdit(Item item)
        {
            return View(item);
        }
        [HttpPost, ActionName("IEdit")]
        [ValidateAntiForgeryToken]
        public ActionResult IEditPost([Bind(Include = "ItemId, ItemName, ItemPrice")] Item item)

        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Item");
            }
            return View(item);
        }

        public ActionResult ICreate()
        {
            return View();
        }
        [HttpPost, ActionName("ICreate")]
        [ValidateAntiForgeryToken]
        public ActionResult ICreate([Bind(Include = "ItemId, ItemName, ItemPrice")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Item");
            }
            return View(item);
        }

        public ActionResult IDelete(Item item)
        {
            return View(item);
        }
        [HttpPost, ActionName("IDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult IDeleteConfirmed(int ItemId)
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
    
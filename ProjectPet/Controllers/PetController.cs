using ProjectPet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjectPet.Controllers
{
    public class PetController : Controller
    {
        Database1Entities2 db = new Database1Entities2();

        // GET: Pet
        public ActionResult CreatePet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePet(Pet pet, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Images/") + file.FileName);
                    pet.image = file.FileName;
                }
                db.Pets.Add(pet);
                db.SaveChanges();
                return RedirectToAction("ViewPet");
                
            }
            return View(pet);
        }

        public ActionResult ViewPet()
        {

            return View(db.Pets.ToList());
        }


        public ActionResult EditPet(Pet pet)
        {
            return View(pet);
        }
        [HttpPost, ActionName("EditPet")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPet([Bind(Include = "PetId, Name, Price, Breed, Age, Description, image")] Pet pet, HttpPostedFileBase file)

        {
            if (file != null)
            {
                file.SaveAs(HttpContext.Server.MapPath("~/Images/") + file.FileName);
                pet.image = file.FileName;
            }
                    db.Entry(pet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewPet");
            
           
        }



        public ActionResult DeletePet(Pet pet)
        {
            return View(pet);
        }

        [HttpPost, ActionName("DeletePet")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePetConfirmed(int PetId)
        {
            Pet pet = db.Pets.Find(PetId);

            db.Pets.Remove(pet);
            db.SaveChanges();
            return RedirectToAction("ViewPet");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult AvailablePets()
        {
            return View(db.Pets.ToList());
        }
    }
}

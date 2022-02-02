using ProjectPet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace ProjectPet.Controllers
{
    public class AccountController : Controller
    {
        Database1Entities2 db = new Database1Entities2();
        // GET: Account
        [HttpGet]

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index([Bind(Include ="User_Name, User_Email, DOB, PhoneNo, Password, Re_Password")] User us)
        {
            db.Users.Add(us);
            db.SaveChanges();

            return RedirectToAction("Login","Account");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(User us)
        {
            var Obj = db.Users.Where(x => x.User_Name.Equals(us.User_Name) && x.Password.Equals(us.Password)).FirstOrDefault();
            if (Obj != null)
            {
                return RedirectToAction("Home","Home");

            }
            else if (us.User_Name == "admin" && us.Password == "admin")
            {
                return RedirectToAction("Admin","Home");
            }
            else
            {
                MessageBox.Show("Incorrect UserName or Password", "alter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return View();
        }
    }
}
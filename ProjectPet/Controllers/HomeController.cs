using ProjectPet.Models;
using ProjectPet.Repositories;
using ProjectPet.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;



namespace ProjectPet.Controllers
{

    public class HomeController : Controller
    {
        private Database1Entities2 objdatabase1Entities;
        public HomeController()
        {
            objdatabase1Entities = new Database1Entities2();
        }
        Database1Entities2 db = new Database1Entities2();
        private Database1Entities2 objDatabase1Entities;

        // GET: Home
       
        public ActionResult Employ()
        {
            var objCustomerRepository = new CustomerRepository();
            var objItemRepository = new ItemRepository();
            var objPaymentTypeRepository = new PaymentTypeRepository();

            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
                (objCustomerRepository.GetAllCustomer(), objItemRepository.GetAllItems(), objPaymentTypeRepository.GetAllPaymentType());
            return View(objMultipleModels);
        }
        [HttpGet]
        public JsonResult getItemUnitPrice(int itemId)
        {
            decimal UnitPrice = objdatabase1Entities.Items.Single(model => model.ItemId == itemId).ItemPrice;
            return Json(UnitPrice, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Employ(OrderViewModel objOrderViewModel)
        {

            OrderRepository objOrderRepository = new OrderRepository();
            bool isStatus = objOrderRepository.AddOrder(objOrderRepository);
            string SuccessMessage = String.Empty;

            if (isStatus)
            {
                SuccessMessage = "Your Order has been successfully placed";

            }
            else
            {
                SuccessMessage = "There is some issue while placing order";
            }
            return Json(SuccessMessage, JsonRequestBehavior.AllowGet);
        }






        [HttpGet]
        public ActionResult Admin()
        {
            return View();

        }

        public ActionResult Home()
        {
            return View();
        }
        [HttpGet]
        public ActionResult contacts()
        {

            return View();
        }
        [HttpPost]
        public ActionResult contacts([Bind(Include = "FeedId, CustName, CustMail, CustPhone, CustFeedback")]Feedback feedback)
        {
            db.Feedbacks.Add(feedback);
            db.SaveChanges();
            return View(feedback);
        }
        public ActionResult about()
        {
            return View();
        }

        public ActionResult services()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AdItems()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdItems([Bind(Include = "ItemId,ItemName,ItemPrice")] Item it)
        {
            db.Items.Add(it);
            db.SaveChanges();
            return View();
        }

        public ActionResult Pets()
        {
            return View();
        }

      
    }
}
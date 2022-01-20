using ProjectPet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectPet.Repositories
{
    public class CustomerRepository
    {
            private Database1Entities2 objDatabase1Entities;
            public CustomerRepository()
            {
                objDatabase1Entities = new Database1Entities2();

            }
            public IEnumerable<SelectListItem> GetAllCustomer()
            {
                IEnumerable<SelectListItem> objSelectListItems = new List<SelectListItem>();
                objSelectListItems = (from obj in objDatabase1Entities.Customers
                                      select new SelectListItem()
                                      {
                                          Text = obj.CustomerName,
                                          Value = obj.CustomerId.ToString(),
                                          Selected = true
                                      }).ToList();
                return objSelectListItems;
        }
        }
}
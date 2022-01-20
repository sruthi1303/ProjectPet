using ProjectPet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectPet.Repositories
{
    public class ItemRepository
    {
        private Database1Entities2 objDatabase1Entities;
        public ItemRepository()
        {
            objDatabase1Entities = new Database1Entities2();

        }
        public IEnumerable<SelectListItem> GetAllItems()
        {
           var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objDatabase1Entities.Items
                                  select new SelectListItem()
                                  {
                                      Text = obj.ItemName,
                                      Value = obj.ItemId.ToString(),
                                      Selected = false
                                  }).ToList();
            return objSelectListItems;
        }
      


    }
}
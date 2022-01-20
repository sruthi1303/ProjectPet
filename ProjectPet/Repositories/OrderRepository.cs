using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectPet.Models;
using ProjectPet.ViewModel;

namespace ProjectPet.Repositories
{
    public class OrderRepository
    {
        Database1Entities2 db = new Database1Entities2();


        public bool AddOrder(OrderViewModel orderViewModel)
        {
            try
            {
                Order objOrder = new Order()
                {
                    CustomerId = orderViewModel.CustomerId,
                    FinalTotal_ = orderViewModel.FinalTotal,
                    OrderDate = orderViewModel.OrderDate,
                    OrderNumber = String.Format("{0:ddmmyyyyhhmmss}", DateTime.Now),
                    PaymentTypeId = orderViewModel.PaymentTypeId,
                };
                db.Orders.Add(objOrder);
                db.SaveChanges();
                

                foreach (var item in orderViewModel.listOrderDetailViewModel)
                {
                    var objOrderDetails = new OrderDetail()
                    {
                        Discount = item.Discount,
                        ItemId = item.ItemId,
                        Quantity = item.Quantity,
                        OrderId = objOrder.OrderId,
                        Total = item.Total,
                        UnitPrice = item.UnitPrice
                    };
                    db.OrderDetails.Add(objOrderDetails);
                    db.SaveChanges();

                    Transaction objTransaction = new Transaction()
                    {
                        ItemId = item.ItemId,
                        Quantity = (-1) * item.Quantity,
                        TransactionDate = orderViewModel.OrderDate,
                        TypeId = 2
                    };
                    db.Transactions.Add(objTransaction);
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal bool AddOrder(OrderRepository objOrderRepository)
        {
            throw new NotImplementedException();
        }
    }
}
using DAL.Criteria;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class OrderRepo : Repo, IRepo<Order, int, bool>, IOrderStatus<OrderStatus>, ICustomerOrderRepo<Order, int>
    {
        public bool Create(Order obj)
        {
            db.Orders.Add(obj);
            return db.SaveChanges() > 0 ? true: false;
        }
        public bool ChangeOrderStatus(OrderStatus os)
        {
            var ex = Read(os.OrderId);
            if (ex !=null)
            {
                switch(os.Status)
                {
                    case "Pending":
                        ex.SetStatusPending();
                        ex.SetPaymentStatusPending();
                        break;
                    case "Confirm":
                        ex.SetStatusConfirm();
                        break;
                    case "On The Way":
                        ex.SetStatusOnTheWay();
                        break;
                    case "Delivered":
                        ex.SetStatusDelivered();
                        ex.SetPaymentStatusCompleted();
                        break;
                    case "Canceled":
                        ex.SetStatusCancled();
                        ex.SetPaymentStatusCancled();
                        break;
                }
                return db.SaveChanges()>0 ? true: false;
            }
            return false;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> Read()
        {
            return db.Orders.ToList();
        }

        public Order Read(int id)
        {
            return db.Orders.Find(id);
        }

        public bool Update(Order obj)
        {
            throw new NotImplementedException();
        }

        public List<Order> CustomerOrders(int id)// just for customer
        {
            var data = db.Orders.Where(order => order.CustomerId == id).ToList();
            if(data.Count > 0)
            {
                return data;
            }
            return null;
        }

        public Order CustomerOrderDetails(int orderId)// just for customer
        {
            var data = db.Orders.Find(orderId);
            if (data != null) return data;
            return null;
        }
    }
}

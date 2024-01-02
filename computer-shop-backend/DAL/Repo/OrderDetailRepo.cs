using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class OrderDetailRepo : Repo, IOrderDetail<OrderDetail, int, bool>
    {
        public bool Create(OrderDetail obj)
        {
            db.OrderDetails.Add(obj);
            return db.SaveChanges() > 0;
        }

        public List<OrderDetail> Get(int orderId)
        {
            return db.OrderDetails.Where(d=>d.OrderId==orderId).ToList();
        }

        public List<OrderDetail> Get()
        {
            return db.OrderDetails.ToList();
        }
    }
}

using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class CustomerRepo : Repo, IRepo<Customer, int, Customer>, IAuth<bool>
    {
        public bool Authenticate(string email, string password)
        {
            var data = db.Customers.FirstOrDefault(u => u.Email.Equals(email) && u.password.Equals(password));
            if(data != null) return true;
            return false;
        }

        public Customer Create(Customer obj)
        {
            db.Customers.Add(obj);
            
            return db.SaveChanges()>0 ? obj : null ;
        }

        public bool Delete(int id)
        {
            var data = Read(id);
            if(data != null)
            {
                db.Customers.Remove(data);
                return db.SaveChanges() > 0;
            };
            return false;
        }

        public List<Customer> Read()
        {
            return db.Customers.ToList();
        }

        public Customer Read(int id)
        {
            return db.Customers.Find(id);
        }

        public Customer Update(Customer obj)
        {
            var ex = Read(obj.Id);
            if(ex != null)
            {
                ex.Address = obj.Address;
                ex.Name = obj.Name;
                ex.Phone = obj.Phone;
            }
            return db.SaveChanges() >0? ex : null;
        }
    }
}

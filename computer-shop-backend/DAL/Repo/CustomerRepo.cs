using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class CustomerRepo : Repo, IRepo<Customer, string, Customer>, IAuth<bool>
    {
        public bool Authenticate(string email, string password)
        {
            /*var data = db.Customer.FirstOrDefault(u => u.Email.Equals(email) && u.Password.Equals(password));
            if(data != null) return true;
            return false;*/
            return true;
        }

        public Customer Create(Customer obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> Get()
        {
            throw new NotImplementedException();
        }

        public Customer Get(string id)
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer obj)
        {
            throw new NotImplementedException();
        }
    }
}

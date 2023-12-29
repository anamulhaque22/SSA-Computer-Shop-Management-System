using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class TokenRepo : Repo, IFacade<Token, string, Token>
    {
        public Token Create(Token obj)
        {
            db.Tokens.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Token> Read()
        {
            throw new NotImplementedException();
        }

        public Token Read(string email)
        {
            return db.Tokens.FirstOrDefault(t => t.Tkey.Equals(email));
        }

        public Token Update(Token obj)
        {
            var token = Read(obj.Tkey);
            db.Entry(token).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
                return token;
            return null;
        }

        public Dictionary<string, decimal> ReadForPieChart()

        {

            throw new NotImplementedException();

        }
    }
}

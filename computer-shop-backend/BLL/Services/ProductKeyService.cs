using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductKeyService
    {
        public static bool IsValid(string Key)
        {
            return DataAccessFactory.ProductKeyData().IsValid(Key);
        }
        public static bool Delete(string Key) 
        {
            return DataAccessFactory.ProductKeyData().Delete(Key);
        }
    }
}

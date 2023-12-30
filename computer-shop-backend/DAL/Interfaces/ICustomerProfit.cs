using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICustomerProfit<Type, RET>
    {
        RET Update(Type obj);
        List<Type> GetTop3Customers();
    }
}

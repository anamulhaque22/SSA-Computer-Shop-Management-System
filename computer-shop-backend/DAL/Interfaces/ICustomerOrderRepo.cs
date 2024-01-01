using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICustomerOrderRepo<Type, Id>
    {
        List<Type> CustomerOrders(Id id);
        Type CustomerOrderDetails(Id orderId);
    }
}

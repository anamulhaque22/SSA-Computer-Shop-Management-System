using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public interface IOrderStatus<Type>
    {
        bool ChangeOrderStatus(Type type);
    }
}

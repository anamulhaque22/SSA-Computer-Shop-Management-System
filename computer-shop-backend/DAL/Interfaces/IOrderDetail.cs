using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOrderDetail<Type, ID, RET>
    {
        RET Create(Type obj);
        List<Type> Get(ID obj);
        List<Type> Get();
    }
}

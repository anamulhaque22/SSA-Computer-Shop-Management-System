using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAdmin<Type, Username, RET>
    {
        RET Create(Type obj);
        //List<Type> Get();
        Type Get(Username username);
        RET Update(Type obj);
        RET UpdatePassword(Type obj);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAdminRepo<Type, Username, RET>
    {
        RET Create(Type obj);
        //List<Type> Get();
        Type Get(Username username);
        Type GetWithoutPassword(Username username);
        RET Update(Type obj);
    }
}

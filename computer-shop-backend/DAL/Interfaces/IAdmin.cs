using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAdmin<Type, UniqueIdentifier, RET>
    {
        RET Create(Type obj);
        //List<Type> Get();
        RET isUniqueEmail(UniqueIdentifier email);
        Type Get(UniqueIdentifier username);
        RET Update(Type obj);
        RET UpdateSpecificField(Type obj);
    }
}

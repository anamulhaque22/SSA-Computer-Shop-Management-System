using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEmployee<Type, RET, ID>
    {
        Type GetEmployeeOfTheMonth();
        RET Approve(ID Id);
        RET Delete(ID Id);
        List<Type> Get();
    }
}

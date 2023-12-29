using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
<<<<<<<< HEAD:computer-shop-backend/DAL/Interfaces/IAdminRepo.cs
    public interface IAdminRepo<Type, Username, RET>
========
    public interface IFacade<Type, ID, RET>
>>>>>>>> 8905d0f559cfb47f630c611a4d8a4cd5c2033cc3:computer-shop-backend/DAL/Interfaces/IFacade.cs
    {
        RET Create(Type obj);
        //List<Type> Get();
        Type Get(Username username);
        Type GetWithoutPassword(Username username);
        RET Update(Type obj);
<<<<<<<< HEAD:computer-shop-backend/DAL/Interfaces/IAdminRepo.cs
========

        bool Delete(ID id);


        Dictionary<string, decimal> ReadForPieChart();
>>>>>>>> 8905d0f559cfb47f630c611a4d8a4cd5c2033cc3:computer-shop-backend/DAL/Interfaces/IFacade.cs
    }
}

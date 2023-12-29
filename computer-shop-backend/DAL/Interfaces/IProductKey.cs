using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProductKey<Key, RET>
    {
        RET IsValid(Key key);
        RET Delete(Key Key);
    }
}

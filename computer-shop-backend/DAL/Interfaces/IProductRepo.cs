﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProductRepo<Type, RET>
    {
        List<RET> FilterProduct(Type obj);
    }
}

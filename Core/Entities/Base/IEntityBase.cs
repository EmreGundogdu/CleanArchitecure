﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Base
{
    public interface IEntityBase<TId>
    {
        TId Id { get;}
    }
}

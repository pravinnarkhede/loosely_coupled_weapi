﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoditasAssignment.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        AssignmentEntities Init();
    }
}

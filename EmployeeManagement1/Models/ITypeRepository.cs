﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement1.Models
{
   public interface ITypeRepository
    {
        IEnumerable<Type> GetTypes();
    }
}

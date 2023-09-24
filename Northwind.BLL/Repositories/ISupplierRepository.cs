﻿using Northwind.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL.Repositories
{
    public interface ISupplierRepository
    {
        IEnumerable<SupplierDTO> GetSuppliers();
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DAL.Models;

namespace Northwind.BLL.DTOs
{
    public class MonthlyRevenueDTO
    {
        public DateTime? Date { get; set; }
        public decimal Revenue { get; set; }
    }
}

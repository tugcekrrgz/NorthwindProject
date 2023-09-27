using Northwind.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL.DTOs
{
    public class CountrySaleDTO
    {
        public int OrderDate { get; set; }
        public string? ShipCountry { get; set; }
        public decimal TotalOrders { get; set; }
    }
}

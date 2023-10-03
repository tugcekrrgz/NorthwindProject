using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL.DTOs
{
    public class SalesCategoriesDTO
    {
        public string CategoryName { get; set; }
        public decimal TotalOrders { get; set; }
    }
}

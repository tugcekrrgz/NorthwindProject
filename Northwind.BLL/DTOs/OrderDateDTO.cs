using Northwind.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL.DTOs
{
    public class OrderDateDTO
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }

        


    }
}

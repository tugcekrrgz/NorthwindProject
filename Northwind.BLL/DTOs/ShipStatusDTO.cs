using Northwind.BLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL.DTOs
{
    public class ShipStatusDTO
    {
        public ShipStatus Status { get; set; }
        public int OrderId { get; set; }
    }
}

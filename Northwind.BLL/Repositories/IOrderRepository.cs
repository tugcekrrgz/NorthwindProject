using Northwind.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<OrderDateDTO> GetOrderDates();
        OrderDateDTO Details(int id);


        IEnumerable<CountrySaleDTO> GetOrdersInYear(int orderYear);
        IEnumerable<ShipStatusDTO> GetShipStatus();
        IEnumerable<MonthlyRevenueDTO> GetMonthlyRevenue(int year, int month);
    }
}

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
        //Hangi tarihte hangi satışların yapıldığı
        IEnumerable<OrderDateDTO> GetOrderDates();
        OrderDateDTO Details(int id);

        //O yıl içerisinde en çok satış yapılan ülkelerin listelenmesi.
        IEnumerable<CountrySaleDTO> GetOrdersInYear(int orderYear);
        
        //Satışların kargo durumunun gösterilmesi
        IEnumerable<ShipStatusDTO> GetShipStatus();

        //Aylık olarak yapılan satışlardan elde edilen net kazanç
        IEnumerable<MonthlyRevenueDTO> GetMonthlyRevenue(int year, int month);
    }
}

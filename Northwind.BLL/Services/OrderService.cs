using Northwind.BLL.DTOs;
using Northwind.BLL.Repositories;
using Northwind.DAL.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL.Services
{
    public class OrderService : IOrderRepository
    {
        private readonly NorthwindContext _context;

        public OrderService(NorthwindContext context)
        {
            _context = context;
        }

        public OrderDateDTO Details(int id)
        {
            try
            {
                var details = _context.Orders.Where(x => x.OrderId==id).Select(x => new OrderDateDTO
                {
                    OrderId = id,
                    OrderDate = x.OrderDate
                }).FirstOrDefault();

                return details;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public IEnumerable<MonthlyRevenueDTO> GetMonthlyRevenue(int year, int month)
        {
            var monthlyRevenue = from o in _context.Orders
                                 join od in _context.OrderDetails on o.OrderId equals od.OrderId
                                 where o.OrderDate.Value.Year == year && o.OrderDate.Value.Month == month
                                 group new { o.OrderDate, od.Quantity, od.UnitPrice } by o.OrderDate into orderDateGroup
                                 orderby orderDateGroup.Sum(x => x.Quantity * x.UnitPrice) descending
                                 select new MonthlyRevenueDTO
                                 {
                                     Date = orderDateGroup.Key,
                                     Revenue = orderDateGroup.Sum(x => x.UnitPrice*x.Quantity)
                                 };
            return monthlyRevenue;
        }

        public IEnumerable<OrderDateDTO> GetOrderDates()
        {
            var salesDate = from o in _context.Orders
                            join od in _context.OrderDetails on o.OrderId equals od.OrderId

                            select new OrderDateDTO
                            {
                                OrderDate=o.OrderDate,
                                OrderId=od.OrderId
                            };
            return salesDate;
        }

        public IEnumerable<CountrySaleDTO> GetOrdersInYear(int orderYear)
        {
            var salefOfYear = from o in _context.Orders
                              join od in _context.OrderDetails on o.OrderId equals od.OrderId
                              where o.OrderDate.Value.Year == orderYear
                              group new { o.ShipCountry, od.Quantity, od.UnitPrice } by o.ShipCountry into countryGroup
                              orderby countryGroup.Sum(x => x.Quantity * x.UnitPrice) descending
                              select new CountrySaleDTO
                              {
                                  ShipCountry=countryGroup.Key,
                                  TotalOrders=countryGroup.Sum(x => x.Quantity*x.UnitPrice),
                                  OrderDate=orderYear
                              };
            return salefOfYear;
        }

        public IEnumerable<ShipStatusDTO> GetShipStatus()
        {
            var shipStatus = _context.Orders.Select(x => new ShipStatusDTO
            {
                OrderId=x.OrderId,
                //Ternary if
                Status = x.ShippedDate == null ? Enums.ShipStatus.Bekliyor : Enums.ShipStatus.Tasimada
            }) ;

            return shipStatus;
        }
    }
}

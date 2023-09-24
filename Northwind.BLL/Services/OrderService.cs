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

        public OrderDTO Details(int id)
        {
            try
            {
                var details = _context.Orders.Where(x => x.OrderId==id).Select(x => new OrderDTO
                {
                    OrderId = id,
                    OrderDate = x.OrderDate,    
                    OrderDetail= _context.OrderDetails.Where(od => od.OrderId == id).ToList(),
                    
                }).FirstOrDefault();

                return details;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public IEnumerable<OrderDTO> GetOrders()
        {
            try
            {
                var orderDto = _context.Orders.Select(x => new OrderDTO
                {
                    OrderId = x.OrderId,
                    OrderDate = x.OrderDate
                });
                return orderDto.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

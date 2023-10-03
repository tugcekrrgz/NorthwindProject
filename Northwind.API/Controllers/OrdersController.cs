using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.BLL.Repositories;

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        [Route("getorderdate")]
        public IActionResult Get()
        {
            var orders = _orderRepository.GetOrderDates();
            return Ok(orders);
        }

        [HttpGet]
        [Route("details/{id}")]
        public IActionResult Details(int id)
        {
            var detail=_orderRepository.Details(id);
            return Ok(detail);
        }

        [HttpGet]
        [Route("getCountrySale")]
        public IActionResult GetCountrySale() 
        {
            var countrySales = _orderRepository.GetOrdersInYear(1996).ToList();
            return Ok(countrySales);
        }

        [HttpGet]
        [Route("getShipStatus")]
        public IActionResult GetShipStatus()
        {
            var shipStatus = _orderRepository.GetShipStatus().ToList();
            Dictionary<int, string> status = new Dictionary<int, string>();
            foreach(var ship in shipStatus)
            {
                status.Add(ship.OrderId, Enum.GetName(ship.Status));
            }
            return Ok(status);
        }

        [HttpGet]
        [Route("getmonthlyrevenue/{year}/{month}")]
        public IActionResult GetMonthlyRevenue(int year, int month)
        {
            var monthlyRevenue = _orderRepository.GetMonthlyRevenue(year,month).ToList();
            return Ok(monthlyRevenue);
        }

        [HttpGet]
        [Route("salescategories")]
        public IActionResult SalesCategories()
        {
            var salescategories = _orderRepository.GetSalesCategories();
            return Ok(salescategories);
        }
    }
}

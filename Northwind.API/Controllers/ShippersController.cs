using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.BLL.Repositories;

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly IShipperRepository _shipperRepository;

        public ShippersController(IShipperRepository shipperRepository)
        {
            _shipperRepository = shipperRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_shipperRepository.GetShippers());
        }
    }
}

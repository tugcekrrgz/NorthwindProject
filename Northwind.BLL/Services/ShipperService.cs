using Northwind.BLL.DTOs;
using Northwind.BLL.Repositories;
using Northwind.DAL.Models;

namespace Northwind.BLL.Services
{
    public class ShipperService : IShipperRepository
    {
        private readonly NorthwindContext _context;

        public ShipperService(NorthwindContext context)
        {
            _context = context;
        }
        public IEnumerable<ShipperDTO> GetShippers()
        {
            try
            {
                var shipperDto = _context.Shippers.Select(x => new ShipperDTO
                {
                    ShipperId = x.ShipperId,
                    CompanyName = x.CompanyName,
                    Phone = x.Phone
                });
                return shipperDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

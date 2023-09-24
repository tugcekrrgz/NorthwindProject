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

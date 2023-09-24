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
    public class SupplierService : ISupplierRepository
    {
        private readonly NorthwindContext _context;

        public SupplierService(NorthwindContext context)
        {
            _context = context;
        }
        public IEnumerable<SupplierDTO> GetSuppliers()
        {
            try
            {
                var supplierDto= _context.Suppliers.Select(x => new SupplierDTO
                {
                    SupplierId = x.SupplierId,
                    CompanyName = x.CompanyName,
                    ContactName = x.ContactName
                });

                return supplierDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

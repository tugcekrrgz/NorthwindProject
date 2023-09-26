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
    public class CategoryService : ICategoryRepository
    {
        private readonly NorthwindContext _context;

        public CategoryService(NorthwindContext context)
        {
            _context = context;
        }

        public List<CategoryDTO> GetAllCategories()
        {
            var categories = from c in _context.Categories
                             select new CategoryDTO
                             {
                                 CategoryId = c.CategoryId,
                                 CategoryName = c.CategoryName,
                                 Description = c.Description
                             };
            return categories.ToList();
        }
    }
}

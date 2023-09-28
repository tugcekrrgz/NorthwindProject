using Northwind.BLL.DTOs;
using Northwind.BLL.Repositories;
using Northwind.DAL.Models;

namespace Northwind.BLL.Services
{
    public class ProductService : IProductRepository
    {
        private readonly NorthwindContext _context;

        public ProductService(NorthwindContext context)
        {
            _context = context;
        }

        public string DeleteProduct(int id)
        {
            var product = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            if (product == null)
            {
                return "The product cannot be found";
            }
            else
            {
                _context.Products.Remove(product);
                return product.ProductName + " is deleted";
            }
        }

        public List<ProductDTO> GetAllProducts()
        {
            var products = from p in _context.Products
                           join c in _context.Categories on p.CategoryId equals c.CategoryId
                           join s in _context.Suppliers on p.SupplierId equals s.SupplierId
                           select new ProductDTO
                           {
                               ProductId = p.ProductId,
                               UnitPrice = p.UnitPrice,
                               ProductName = p.ProductName,
                               UnitsInStock = p.UnitsInStock,
                               Category = c,
                               Supplier = s

                           };
            return products.ToList();
        }

        public ProductDTO GetProductById(int id)
        {
            var product = _context.Products.Where(x => x.ProductId == id).Select(x => new ProductDTO
            {
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                ProductId = x.ProductId,
                UnitsInStock = x.UnitsInStock,
                Category = x.Category,
                Supplier = x.Supplier

            }).FirstOrDefault();
            return product;
            //product boş ise nasıl if else yapısına return yapacağım? bad request dönemiyorum?
        }

        public List<ProductDTO> GetProductsByCategory(string cname)
        {
            var products = GetAllProducts().Where(x => x.Category.CategoryName == cname);
            return products.ToList();
        }

        public ProductDTO UpdateProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}

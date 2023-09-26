using Northwind.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL.Repositories
{
    public interface IProductRepository
    {
        List<ProductDTO> GetAllProducts();
        ProductDTO GetProductById(int id);
        string DeleteProduct(int id);
        ProductDTO UpdateProduct(int id);
        List<ProductDTO> GetProductsByCategory(string cname);
    }
}

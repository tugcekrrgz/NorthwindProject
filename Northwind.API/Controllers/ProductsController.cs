﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.BLL.Repositories;

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("getproducts")]
        public IActionResult GetProducts()
        {
            var products = _productRepository.GetAllProducts();
            return Ok(products);
        }
        [HttpGet]
        [Route("getproduct/{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _productRepository.GetProductById(id);
            return Ok(product);
        }
        [HttpGet]
        [Route("getproductsby/{cname}")]
        public IActionResult GetProductByCategory(string cname)
        {

            var products = _productRepository.GetAllProducts().Where(x => x.Category.CategoryName == cname);

            return Ok(products);
        }
    }
}

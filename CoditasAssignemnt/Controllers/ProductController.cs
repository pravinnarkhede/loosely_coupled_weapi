using CoditasAssignment.Data;
using CoditasAssignment.Data.Infrastructure;
using CoditasAssignment.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoditasAssignment.Data.ViewModel;

namespace CoditasAssignemnt.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: api/Product
        public Response<List<ProductViewModel>> Get()
        {
            var products = productService.GetProducts();
            return products;
        }

        // GET: api/Product/5
        public Response<ProductViewModel> Get(int id)
        {
            var product = productService.GetProduct(id);
            return product;
        }

        // POST: api/Product
        public Response<ProductViewModel> Post(ProductViewModel product)
        {
            return productService.AddProduct(product);
        }

        // PUT: api/Product/5
        public Response<ProductViewModel> Put(ProductViewModel product)
        {
            return productService.UpdateProduct(product);
        }

        // DELETE: api/Product/5
        public Response<ProductViewModel> Delete(int id)
        {
            return productService.DeleteProduct(id);
        }
    }
}


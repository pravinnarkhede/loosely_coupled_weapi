using System;
using System.Collections.Generic;
using System.Linq;
using CoditasAssignment.Data;
using CoditasAssignment.Data.Infrastructure;
using CoditasAssignment.Data.Repositories;

namespace CoditasAssignment.Service
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts(string name = null);
        Product GetProduct(int id);
        Product GetProduct(string name);
        Product AddProduct(Product product);
        Product UpdateProduct(Product product);
        bool DeleteProduct(int id);
        void SaveProduct();
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository orderRepository;

        private readonly IUnitOfWork unitOfWork;

        public ProductService(IProductRepository productRepository, IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IProductService Members

        public IEnumerable<Product> GetProducts(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return productRepository.GetAll();
            else
                return productRepository.GetAll().Where(c => c.name == name);
        }

        public Product GetProduct(int id)
        {
            var product = productRepository.GetById(id);
            return product;
        }

        public Product GetProduct(string name)
        {
            var product = productRepository.GetProductByName(name);
            return product;
        }

        public Product AddProduct(Product product)
        {
            productRepository.Add(product);
            SaveProduct();
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            productRepository.Update(product);
            SaveProduct();
            return product;
        }

        public bool DeleteProduct(int id)
        {
            var product = GetProduct(id);
            if (product == null)
                return false;

            if (orderRepository.GetAll().SelectMany(c => c.OrderProducts.Where(f=>f.product_id == id)).Count() > 0)
                return false;

            productRepository.Delete(product);
            SaveProduct();
            return true;
        }

        public void SaveProduct()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}

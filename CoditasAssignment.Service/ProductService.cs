using System;
using System.Collections.Generic;
using System.Linq;
using CoditasAssignment.Data;
using CoditasAssignment.Data.Infrastructure;
using CoditasAssignment.Data.Repositories;
using CoditasAssignment.Data.ViewModel;

namespace CoditasAssignment.Service
{
    public interface IProductService
    {
        Response<List<ProductViewModel>> GetProducts(string name = null);
        Response<ProductViewModel> GetProduct(int id);
        Response<ProductViewModel> GetProduct(string name);
        Response<ProductViewModel> AddProduct(ProductViewModel product);
        Response<ProductViewModel> UpdateProduct(ProductViewModel product);
        Response<ProductViewModel> DeleteProduct(int id);
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

        public Response<List<ProductViewModel>> GetProducts(string name = null)
        {
            var products = new List<Product>();
            if (string.IsNullOrEmpty(name))
                products = productRepository.GetAll().ToList();
            else
                products = productRepository.GetAll().Where(c => c.name == name).ToList();

            return new Response<List<ProductViewModel>>
            {
                Status = 1,
                Record = products.Select(s => new ProductViewModel
                {
                    Id = s.id,
                    Name = s.name,
                    Modifires = s.Modifires.Select(m => new ModifireViewModel
                    {
                        Id = m.id,
                        Name = m.name,
                        Price = m.price
                    }).ToList(),
                }).ToList(),
                Message = "Success"
            };
        }

        public Response<ProductViewModel> GetProduct(int id)
        {
            var product = productRepository.GetById(id);
            if (product == null)
                return new Response<ProductViewModel> { Status = 0, Message = "No record found" };

            return new Response<ProductViewModel>
            {
                Status = 1,
                Record = new ProductViewModel
                {
                    Id = product.id,
                    Name = product.name,
                    Modifires = product.Modifires.Select(m => new ModifireViewModel
                    {
                        Id = m.id,
                        Name = m.name,
                        Price = m.price
                    }).ToList()
                },
                Message = "Success"
            };
        }

        public Response<ProductViewModel> GetProduct(string name)
        {
            var product = productRepository.GetProductByName(name);
            if (product == null)
                return new Response<ProductViewModel> { Status = 0, Message = "No record found" };

            return new Response<ProductViewModel>
            {
                Status = 1,
                Record = new ProductViewModel
                {
                    Id = product.id,
                    Name = product.name,
                    Modifires = product.Modifires.Select(m => new ModifireViewModel
                    {
                        Id = m.id,
                        Name = m.name,
                        Price = m.price
                    }).ToList()
                },
                Message = "Success"
            };
        }

        public Response<ProductViewModel> AddProduct(ProductViewModel product)
        {
            productRepository.Add(new Product
            {
                name = product.Name,
                price = product.Price,
                category_id = product.CategoryId,
                Modifires = product.Modifires.Select(m=>new Modifire
                {
                    name = m.Name,
                    price = m.Price
                }).ToList() 
            });
            SaveProduct();

            return new Response<ProductViewModel>
            {
                Status = 1,
                Record = product,
                Message = "Success"
            };
        }

        public Response<ProductViewModel> UpdateProduct(ProductViewModel product)
        {
            var existingProduct = GetProduct(product.Id);
            if (existingProduct == null)
                return new Response<ProductViewModel>
                {
                    Status = 1,
                    Record = product,
                    Message = "Success"
                };

            //productRepository.Update(existingProduct.Record);
            //SaveProduct();
            return new Response<ProductViewModel>
            {
                Status = 1,
                Record = product,
                Message = "Success"
            };
        }

        public Response<ProductViewModel> DeleteProduct(int id)
        {
            return null;
            //var product = GetProduct(id);
            //if (product == null)
            //    return false;

            //if (orderRepository.GetAll().SelectMany(c => c.OrderProducts.Where(f => f.product_id == id)).Count() > 0)
            //    return false;

            //productRepository.Delete(product);
            //SaveProduct();
            //return true;
        }

        public void SaveProduct()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}

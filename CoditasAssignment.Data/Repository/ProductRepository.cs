using CoditasAssignment.Data.Infrastructure;
using CoditasAssignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoditasAssignment.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Product GetProductByName(string productName)
        {
            var product = this.DbContext.Products.Where(c => c.name == productName).FirstOrDefault();

            return product;
        }

        public override Product Update(Product entity)
        {
            // entity.DateUpdated = DateTime.Now;
           return base.Update(entity);
        }
    }

    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductByName(string productName);
    }
}

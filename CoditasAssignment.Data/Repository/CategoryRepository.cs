using CoditasAssignment.Data.Infrastructure;
using CoditasAssignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoditasAssignment.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Category GetCategoryByName(string categoryName)
        {
            var category = this.DbContext.Categories.Where(c => c.name == categoryName).FirstOrDefault();
            return category;
        }
        public override Category GetById(int id)
        {
            var category = base.GetById(id); 
            return category;
        }

        public override Category Add(Category entity)
        {
           return base.Add(entity);
        }

        public override Category Update(Category entity)
        {
           return base.Update(entity);
        }

        public override void Delete(Category entity)
        {
            base.Delete(entity);
        }
    }

    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetCategoryByName(string categoryName);       
    }
}

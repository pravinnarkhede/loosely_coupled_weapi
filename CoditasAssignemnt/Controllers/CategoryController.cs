using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoditasAssignment.Data;
using CoditasAssignment.Service;

namespace CoditasAssignment.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: api/Category
        public IEnumerable<Category> Get()
        {
           var categories = categoryService.GetCategories().ToList();
            return categories;
        }

        // GET: api/Category/5
        public Category Get(int id)
        {
           var category = categoryService.GetCategory(id);
            return category;
        }

        // POST: api/Category
        public Category Post(Category category)
        {
            return categoryService.AddCategory(category);
        }

        // PUT: api/Category/5
        public Category Put(Category category)
        {
            return categoryService.UpdateCategory(category);
        }

        // DELETE: api/Category/5
        public bool Delete(int id)
        {
            return categoryService.DeleteCategory(id);
        }
    }
}

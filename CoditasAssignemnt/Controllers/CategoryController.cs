using System.Collections.Generic;
using System.Web.Http;
using CoditasAssignment.Data.Infrastructure;
using CoditasAssignment.Data.ViewModel;
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
        public Response<List<CategoryViewModel>> Get()
        {
            return categoryService.GetCategories();
        }

        // GET: api/Category/5
        public Response<CategoryViewModel> Get(int id)
        {
            return categoryService.GetCategory(id);
        }

        // POST: api/Category
        public Response<CategoryViewModel> Post(CategoryViewModel category)
        {
            return categoryService.AddCategory(category);
        }

        // PUT: api/Category/5
        public Response<CategoryViewModel> Put(CategoryViewModel category)
        {
            return categoryService.UpdateCategory(category);
        }

        // DELETE: api/Category/5
        public Response<CategoryViewModel> Delete(int id)
        {
            return categoryService.DeleteCategory(id);
        }
    }
}

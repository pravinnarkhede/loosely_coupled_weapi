using System.Collections.Generic;
using System.Linq;
using CoditasAssignment.Data;
using CoditasAssignment.Data.Infrastructure;
using CoditasAssignment.Data.Repositories;
using CoditasAssignment.Data.ViewModel;

namespace CoditasAssignment.Service
{
    public interface ICategoryService
    {
        Response<List<CategoryViewModel>> GetCategories(string name = null);
        Response<CategoryViewModel> GetCategory(int id);
        Response<CategoryViewModel> GetCategory(string name);
        Response<CategoryViewModel> AddCategory(CategoryViewModel category);
        Response<CategoryViewModel> UpdateCategory(CategoryViewModel category);
        Response<CategoryViewModel> DeleteCategory(int id);
        void SaveCategory();
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IProductRepository productRepository;

        private readonly IUnitOfWork unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public Response<List<CategoryViewModel>> GetCategories(string name = null)
        {
            var categories = new List<Category>();
            if (string.IsNullOrEmpty(name))
                categories = categoryRepository.GetAll().ToList();
            else
                categories = categoryRepository.GetAll().Where(c => c.name == name).ToList();

            return new Response<List<CategoryViewModel>>
            {
                Status = 1,
                Record = categories.Select(s => new CategoryViewModel { id = s.id, name = s.name }).ToList(),
                Message = "Success"
            };
        }

        public Response<CategoryViewModel> GetCategory(int id)
        {
            var category = categoryRepository.GetById(id);
            if (category == null)
                return new Response<CategoryViewModel> { Status = 0, Message = "No record found" };

            return new Response<CategoryViewModel>
            {
                Status = 1,
                Record = new CategoryViewModel { id = category.id, name = category.name },
                Message = "Success"
            };
        }

        public Response<CategoryViewModel> GetCategory(string name)
        {
            var category = categoryRepository.GetCategoryByName(name);
            if (category == null)
                return new Response<CategoryViewModel> { Status = 0, Message = "No record found" };

            return new Response<CategoryViewModel>
            {
                Status = 1,
                Record = new CategoryViewModel { id = category.id, name = category.name },
                Message = "Success"
            };
        }

        public Response<CategoryViewModel> AddCategory(CategoryViewModel category)
        {
            categoryRepository.Add(new Category { id = category.id, name = category.name });
            SaveCategory();
            return new Response<CategoryViewModel>
            {
                Status = 1,
                Record = new CategoryViewModel { id = category.id, name = category.name },
                Message = "Success"
            };
        }

        public Response<CategoryViewModel> UpdateCategory(CategoryViewModel category)
        {
            categoryRepository.Update(new Category { id = category.id, name = category.name });
            SaveCategory();
            return new Response<CategoryViewModel>
            {
                Status = 1,
                Record = new CategoryViewModel { id = category.id, name = category.name },
                Message = "Success"
            };
        }

        public Response<CategoryViewModel> DeleteCategory(int id)
        {
            var category = categoryRepository.GetById(id);
            if (category == null)
                return new Response<CategoryViewModel> { Status = 0, Message = "No record found" };

            if (productRepository.GetAll().Where(c => c.category_id == id).Count() > 0)
                return new Response<CategoryViewModel> { Status = 0, Message = "Failed" };

            categoryRepository.Delete(category);
            SaveCategory();
            return new Response<CategoryViewModel>
            {
                Status = 1,
                Record = new CategoryViewModel { id = category.id, name = category.name },
                Message = "Success"
            };
        }

        public void SaveCategory()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}

using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
        private readonly IItemRepository itemRepository;

        private readonly IUnitOfWork unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IItemRepository itemRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.itemRepository = itemRepository;
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

            var categoryViewModel = Mapper.Map<List<Category>, List<CategoryViewModel>>(categories);
            return new Response<List<CategoryViewModel>>
            {
                Status = 1,
                Record = categoryViewModel,
                Message = "Success"
            };
        }

        public Response<CategoryViewModel> GetCategory(int id)
        {
            var category = categoryRepository.GetById(id);
            if (category == null)
                return new Response<CategoryViewModel> { Status = 0, Message = "No record found" };

            var categoryViewModel = Mapper.Map<Category, CategoryViewModel>(category);

            return new Response<CategoryViewModel>
            {
                Status = 1,
                Record = categoryViewModel,
                Message = "Success"
            };
        }

        public Response<CategoryViewModel> GetCategory(string name)
        {
            var category = categoryRepository.GetCategoryByName(name);
            if (category == null)
                return new Response<CategoryViewModel> { Status = 0, Message = "No record found" };

            var categoryViewModel = Mapper.Map<Category, CategoryViewModel>(category);

            return new Response<CategoryViewModel>
            {
                Status = 1,
                Record = categoryViewModel,
                Message = "Success"
            };
        }

        public Response<CategoryViewModel> AddCategory(CategoryViewModel categoryViewModel)
        {
            var category = Mapper.Map<CategoryViewModel, Category>(categoryViewModel);
            categoryRepository.Add(category);
            SaveCategory();

            categoryViewModel = Mapper.Map<Category, CategoryViewModel>(category);
            return new Response<CategoryViewModel>
            {
                Status = 1,
                Record = categoryViewModel,
                Message = "Success"
            };
        }

        public Response<CategoryViewModel> UpdateCategory(CategoryViewModel categoryViewModel)
        {
            var category = Mapper.Map<CategoryViewModel, Category>(categoryViewModel);
            categoryRepository.Update(category);
            SaveCategory();
            categoryViewModel = Mapper.Map<Category, CategoryViewModel>(category);

            return new Response<CategoryViewModel>
            {
                Status = 1,
                Record = categoryViewModel,
                Message = "Success"
            };
        }

        public Response<CategoryViewModel> DeleteCategory(int id)
        {
            var category = categoryRepository.GetById(id);
            if (category == null)
                return new Response<CategoryViewModel> { Status = 0, Message = "No record found" };

            if (itemRepository.GetAll().Where(c => c.category_id == id).Count() > 0)
                return new Response<CategoryViewModel> { Status = 0, Message = "Failed" };

            categoryRepository.Delete(category);
            SaveCategory();
            var categoryViewModel = Mapper.Map<Category, CategoryViewModel>(category);

            return new Response<CategoryViewModel>
            {
                Status = 1,
                Record = categoryViewModel,
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

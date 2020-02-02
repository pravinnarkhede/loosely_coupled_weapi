using System;
using System.Collections.Generic;
using System.Linq;
using CoditasAssignment.Data;
using CoditasAssignment.Data.Infrastructure;
using CoditasAssignment.Data.Repositories;

namespace CoditasAssignment.Service
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories(string name = null);
        Category GetCategory(int id);
        Category GetCategory(string name);
        Category AddCategory(Category category);       
        Category UpdateCategory(Category category);
        bool DeleteCategory(int id);
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

        public IEnumerable<Category> GetCategories(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return categoryRepository.GetAll();
            else
                return categoryRepository.GetAll().Where(c => c.name == name);
        }

        public Category GetCategory(int id)
        {
            var category = categoryRepository.GetById(id);
            return category;
        }

        public Category GetCategory(string name)
        {
            var category = categoryRepository.GetCategoryByName(name);
            return category;
        }

        public Category AddCategory(Category category)
        {
            categoryRepository.Add(category);
            SaveCategory();
            return category;
        }

        public Category UpdateCategory(Category category)
        {
            categoryRepository.Update(category);
            SaveCategory();
            return category;
        }

        public bool DeleteCategory(int id)
        {
            var category = GetCategory(id);
            if (category == null)
                return false;

            if (productRepository.GetAll().Where(c => c.category_id == id).Count() > 0)
                return false;

            categoryRepository.Delete(category);
            SaveCategory();
            return true;
        }

        public void SaveCategory()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}

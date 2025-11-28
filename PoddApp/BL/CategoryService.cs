using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task AddCategoryAsync(string name)
        {
            string trimmedName = name.Trim();
            var category = new Category(trimmedName);
            var DBcategories = await GetAllCategoriesAsync();
            if (DBcategories.Any(c => c.Name.Equals(trimmedName, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("Kategorin finns redan. Vänligen skriv in en ny kategori.");
            }
            await _repository.AddAsync(category);
        }

        public Task<List<Category>> GetAllCategoriesAsync()
        {
            return _repository.GetAllAsync();
        }
        public Task<Category> GetCategoryByIdAsync(string categoryId)
        {
            return _repository.GetByIdAsync(categoryId);
        }

        public async Task RenameCategoryAsync(string categoryId, string newName)
        {
            var category = await _repository.GetByIdAsync(categoryId);
            category.Name = newName;
            await _repository.UpdateAsync(category);
        }

        public async Task DeleteCategoryAsync(string categoryId)
        {
            await _repository.DeleteAsync(categoryId);
        }
    }
}

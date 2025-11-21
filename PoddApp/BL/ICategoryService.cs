using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Threading.Tasks;


namespace BL
{
    public interface ICategoryService
    {
        Task AddCategoryAsync(string name);
        Task <List<Category>> GetAllCategoriesAsync();
        Task <Category> GetCategoryByIdAsync(string id);
        Task RenameCategoryAsync(string categoryId, string newName);
        Task DeleteCategoryAsync(string categoryId);
    }
}

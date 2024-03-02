using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Models;

namespace WebLibrary.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategorys();
        Category GetCategoryByID(int categoryId);
        void InsertCategory(Category admin);
        void DeleteCategory(int categoryId);
        void UpdateCategory(Category admin);
    }
}
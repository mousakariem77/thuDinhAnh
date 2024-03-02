using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.DAO;
using WebLibrary.Models;

namespace WebLibrary.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public Category GetCategoryByID(int categoryId) => CategoryDAO.Instance.GetCategoryByID(categoryId);
        public IEnumerable<Category> GetCategorys() => CategoryDAO.Instance.GetCategorylist();
        public void InsertCategory(Category category) => CategoryDAO.Instance.AddNew(category);
        public void DeleteCategory(int categoryId) => CategoryDAO.Instance.Remove(categoryId);
        public void UpdateCategory(Category category) => CategoryDAO.Instance.Update(category); 
    }
} 
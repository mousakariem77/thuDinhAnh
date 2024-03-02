using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Models;

namespace WebLibrary.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance = null;
        private static readonly object instanceLock = new object();
        public static CategoryDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryDAO();

                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Category> GetCategorylist()
        {
            var category = new List<Category>();
            try
            {
                using var context = new DBContext();
                category = context.Categories.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

                throw;
            }
            return category;
        }

        public Category GetCategoryByID(int categoryID)
        {
            Category category = null;
            try
            {
                using var context = new DBContext();
                category = context.Categories.SingleOrDefault(c => c.CategoryId.Equals(categoryID));

            }
            catch (System.Exception)
            {

                throw;
            }
            return category;
        }

        public void AddNew(Category category)
        {
            try
            {
                Category existingCategory = GetCategoryByID(category.CategoryId);
                if (existingCategory == null)
                {
                    using (var context = new DBContext())
                    {
                        context.Categories.Add(category);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The category already exists.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Category category)
        {
            try
            {
                Category existingCategory = GetCategoryByID(category.CategoryId);
                if (existingCategory != null)
                {
                    using (var context = new DBContext())
                    {
                        context.Categories.Update(category);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The category does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int categoryID)
        {
            try
            {
                Category category = GetCategoryByID(categoryID);
                if (category != null)
                {
                    using (var context = new DBContext())
                    {
                        context.Categories.Remove(category);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The category does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
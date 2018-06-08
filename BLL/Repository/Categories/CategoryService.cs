using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL.Domain;
using BOL.Data;
using DAL;

namespace BLL.Repository.Categories
{
    public partial class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryService;

        public CategoryService()
        {
            _categoryService = new EfRepository<Category>();
        }

        public IList<Category> GetAllCategories()
        {
            return _categoryService.Table.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _categoryService.GetById(id);
        }
    }
}

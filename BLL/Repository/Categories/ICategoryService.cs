using BOL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository.Categories
{
    public partial interface ICategoryService
    {
        IList<Category> GetAllCategories();

        Category GetCategoryById(int id);
    }
}

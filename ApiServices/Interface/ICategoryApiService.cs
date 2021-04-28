using System.Collections.Generic;
using System.Threading.Tasks;
using BlogApp.UI.Models;

namespace BlogApp.UI.ApiServices.Interface
{
    public interface ICategoryApiService
    {
         Task<List<CategoryListModel>> GetAllAsync();
         Task<List<CategoryWithBlogsCountModel>> GetAllWithBlogsCountAsync();
         Task<CategoryListModel> GetByIdAsync(int Id);
         Task AddAsync(CategoryAddModel model);
         Task UpdateAsync(CategoryUpdateModel model);
         Task DeleteAsync(int id);
    }
}
using System.Threading.Tasks;

namespace BlogApp.UI.ApiServices.Interface
{
    public interface IImageApiService
    {
         Task<string> GetBlogImageByIdAsync(int id);
    }
}
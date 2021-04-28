using System.Threading.Tasks;
using BlogApp.UI.Models;

namespace BlogApp.UI.ApiServices.Interface
{
    public interface IAuthApiService
    {
         Task<bool> SignIn(AppUserLoginModel model);
    }
}
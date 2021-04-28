using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BlogApp.UI.ApiServices.Interface;
using BlogApp.UI.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BlogApp.UI.ApiServices.Concrete
{
    public class CategoryApiManager : ICategoryApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _accessor;
        public CategoryApiManager(HttpClient httpClient,IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _httpClient = httpClient;
            httpClient.BaseAddress = new Uri("http://localhost:64501/api/category/");
        }
        public async Task<List<CategoryListModel>> GetAllAsync()
        {
            var responseMessage = await _httpClient.GetAsync("");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<CategoryListModel>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }
        public async Task<List<CategoryWithBlogsCountModel>> GetAllWithBlogsCountAsync()
        {
            var responseMessage = await _httpClient.GetAsync("GetWithBlogsCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<CategoryWithBlogsCountModel>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }
        public async Task<CategoryListModel> GetByIdAsync(int Id)
        {
            var responseMessage = await _httpClient.GetAsync($"{Id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<CategoryListModel>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }
        public async Task AddAsync(CategoryAddModel model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData,Encoding.UTF8,"application/json");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",_accessor.HttpContext.Session.GetString("token"));
        
            await _httpClient.PostAsync("",content);
        }
        public async Task UpdateAsync(CategoryUpdateModel model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData,Encoding.UTF8,"application/json");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",_accessor.HttpContext.Session.GetString("token"));

            await _httpClient.PutAsync($"{model.Id}",content);
        }
        public async Task DeleteAsync(int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",_accessor.HttpContext.Session.GetString("token"));

            await _httpClient.DeleteAsync($"{id}");
        }
    }
}
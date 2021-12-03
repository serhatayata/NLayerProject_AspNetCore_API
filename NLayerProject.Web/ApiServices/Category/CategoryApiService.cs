using Newtonsoft.Json;
using NLayerProject.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Web.ApiServices.Category
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;
        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            IEnumerable<CategoryDTO> categoryDTOs;
            var response = await _httpClient.GetAsync("categories");
            if (response.IsSuccessStatusCode)
            {
                categoryDTOs = JsonConvert.DeserializeObject<IEnumerable<CategoryDTO>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                categoryDTOs = null;
            }
            return categoryDTOs;
        }

        public async Task<CategoryDTO> AddAsync(CategoryDTO categoryDTO)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(categoryDTO),Encoding.UTF8,"application/json");
            var response = await _httpClient.PostAsync("categories", stringContent);
            if (response.IsSuccessStatusCode)
            {
                categoryDTO = JsonConvert.DeserializeObject<CategoryDTO>(await response.Content.ReadAsStringAsync());
                return categoryDTO;
            }
            else
            {
                return null;
            }
        }




    }
}

using Newtonsoft.Json;
using NLayerProject.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Web.ApiServices.Product
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;
        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            IEnumerable<ProductDTO> productDTOs;
            var response = await _httpClient.GetAsync("products");
            if (response.IsSuccessStatusCode)
            {
                productDTOs = JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                productDTOs = null;
            }
            return productDTOs;
        }

        public async Task<ProductDTO> AddAsync(ProductDTO productDTO)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(productDTO), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("products", stringContent);
            if (response.IsSuccessStatusCode)
            {
                productDTO = JsonConvert.DeserializeObject<ProductDTO>(await response.Content.ReadAsStringAsync());
                return productDTO;
            }
            else
            {
                return null;
            }
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"products/{id}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ProductDTO>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Update(ProductDTO productDTO)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(productDTO), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("products", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"products/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }









    }
}

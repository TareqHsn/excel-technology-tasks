using PatientInfo_Web.Models.DTOs;
using System.Net.Http.Headers;

namespace PatientInfo_Web.Services
{
    public class DiseaseApiService
    {
        private readonly HttpClient _httpClient;

        public DiseaseApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5190/api/Diseases/");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Disease>> GetDiseases()
        {
            var response = await _httpClient.GetAsync("");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<Disease>>();
        }

        public async Task<Disease> GetDiseaseById(int id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<Disease>();
        }

        public async Task<int> AddDisease(Disease disease)
        {
            var response = await _httpClient.PostAsJsonAsync("", disease);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<int>();
        }

        public async Task<bool> UpdateDisease(int id, Disease disease)
        {
            var response = await _httpClient.PutAsJsonAsync($"{id}", disease);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteDisease(int id)
        {
            var response = await _httpClient.DeleteAsync($"{id}");
            return response.IsSuccessStatusCode;
        }
    }

}

using PatientInfo_Web.Models.DTOs;
using System.Net.Http.Headers;

namespace PatientInfo_Web.Services
{
    public class PatientApiService
    {
        private readonly HttpClient _httpClient;

        public PatientApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5190/api/patient");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            var response = await _httpClient.GetAsync("");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<Patient>>();
        }
        public async Task<Patient> GetPatientById(int id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<Patient>();
        }

        public async Task<Patient> AddPatient(Patient patient)
        {
            var response = await _httpClient.PostAsJsonAsync("", patient);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<Patient>();
        }

        public async Task<bool> UpdatePatient(int id, Patient patient)
        {
            var response = await _httpClient.PutAsJsonAsync($"{id}", patient);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePatient(int id)
        {
            var response = await _httpClient.DeleteAsync($"{id}");
            return response.IsSuccessStatusCode;
        }
    }


}

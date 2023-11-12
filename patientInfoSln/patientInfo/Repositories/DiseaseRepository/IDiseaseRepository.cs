using patientInfo.Models;

namespace patientInfo.Repositories.DiseaseRepository
{
    public interface IDiseaseRepository
    {
        Task<List<Disease>> GetAllDiseases();
        Task<Disease> GetDiseaseById(int diseaseId);
        Task<int> AddDisease(Disease disease);
        Task UpdateDisease(Disease disease);
        Task DeleteDisease(int diseaseId);
    }
}
